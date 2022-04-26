#nullable disable
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpreadShirtShop.Data;
using SpreadShirtShop.Models;

namespace SpreadShirtShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SpreadShirtShopContext _context;
        private static string Salt = "$2a$12$VvDRKYKGt4Zd2Ux35LeG2OI.Vr5f.UuY2q7MrnHlJj4K5diifQV3z";
        public UsersController(SpreadShirtShopContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // GET: api/Users/5
        [HttpGet("LoginUser/")]
        public async Task<ActionResult<ApiResponse<int>>> LoginUser(string email,string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email.Equals(email))
                .ContinueWith(u =>
                {
                    var user = u.Result;
                    if (user == null)
                    {
                        return new ApiResponse<int> {Message = "Incorrect email or password" , Status = "BadCreds"};
                    }

                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        switch (user.AccountStatus)
                        {
                            case "Ok": return new ApiResponse<int> { Status = "Success", Value = user.Id};
                            case "Waiting for verification.": return new ApiResponse<int> { Message = "Account not verified.", Status = "BadCreds" };
                            default:
                                return new ApiResponse<int> { Message = "Something is wrong", Status = "BadCreds" };
                        }
                    }
                    else
                    {
                        return new ApiResponse<int> { Message = "Incorrect email or password", Status = "BadCreds" };
                    }
                });
        }
        [HttpGet("VerifyUser/")]
        public async Task<ActionResult<String>> VerifyUser(string email, string code)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email))
                .ContinueWith(u =>
                {
                    var user = u.Result;

                    if (user == null)
                    {
                        return "Email not found";
                    }

                    if (user.VerificationCode?.Equals(code) ?? false)
                    {
                        user.AccountStatus = "Ok";
                        _context.SaveChangesAsync();
                        return "Success";
                    }
                    else
                    {
                        return "Wrong code";
                    }
                });
            
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<string>> PostUser(User user)
        {
            if (_context.Users.Any(u => u.Email.Equals(user.Email)))
            {
                return "Email_already_registered";
            }

            var verificationcode = Random.Shared.Next(100000, 999999);
            user.VerificationCode = verificationcode.ToString();
            user.AccountStatus = "Waiting for verification.";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("spreadshirtshopapp@gmail.com", "nrbzwoakugzmbkdk"),
                EnableSsl = true,
            };

            smtpClient
                .Send("spreadshirtshopapp@gmail.com",
                    user.Email,
                    "Spreadshirt shop email confirmation",
                    $"Please click here for verification https://spreadshirtappserver.azurewebsites.net/api/Users/VerifyUser?email={user.Email}&code={user.VerificationCode}"
                    );

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, Salt);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();



            return "Success";
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
