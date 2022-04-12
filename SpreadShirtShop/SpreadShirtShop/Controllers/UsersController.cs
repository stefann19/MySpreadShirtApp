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
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        // GET: api/Users/5
        [HttpGet("LoginUser/")]
        public async Task<ActionResult<String>> LoginUser(string email,string password)
        {
            return await _context.User
                .FirstOrDefaultAsync(u => u.Email.Equals(email))
                .ContinueWith(u =>
                {
                    var user = u.Result;
                    if (user == null)
                    {
                        return "Incorrect_email_or_password";
                    }

                    if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        switch (user.AccountStatus)
                        {
                            case "Ok": return "Success";
                            case "Waiting for verification.": return "Account_not_verified.";
                            default:
                                return "Something_is_wrong";
                        }
                    }
                    else
                    {
                        return "Incorrect_email_or_password";
                    }
                });
        }
        [HttpGet("VerifyUser/")]
        public async Task<ActionResult<String>> VerifyUser(string email, string code)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email.Equals(email))
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
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.User.Any(u => u.Email.Equals(user.Email)))
            {
                return BadRequest("Email already registered");
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
                    $"Please click here for verification https://spreadshirtappserver.azurewebsites.net/api/Users/VerifyUser?email=${user.Email}&code={user.VerificationCode} "
                    );

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, Salt);
            _context.User.Add(user);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
