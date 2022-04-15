#nullable disable
using System.Collections;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpreadShirtShop.Data;
using SpreadShirtShop.Models;

namespace SpreadShirtShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellablesController : ControllerBase
    {
        private readonly SpreadShirtShopContext _context;

        public SellablesController(SpreadShirtShopContext context)
        {
            _context = context;
        }

        // GET: api/Sellables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sellable>>> GetSellables()
        {
            return await _context.Sellables
                .Include(x=> x.PreviewImage)
                .Include(x=> x.Price)
                .Include(x=> x.Tags)
                .Include(x=> x.AppearanceIds)
                .ToListAsync();
        }
        // GET: api/Sellables
        [HttpGet("FetchSellables/")]
        public async Task<ActionResult<String>> FetchSellables()
        {
            var shopId = "1024954";
            var authHeader = "SprdAuth apiKey=\"a7472f4a-b43a-4016-ab4a-d9d5cf8c81c9\"";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri($"https://api.spreadshirt.com/api/v1/");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",authHeader);
            httpClient.DefaultRequestHeaders.UserAgent.Add(ProductInfoHeaderValue.Parse("PostmanRuntime/7.29.0"));
            httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

            var currencies =  (await RetrieveCurrencies(httpClient)).ToList();

            var rawSellables =  await RetrieveSellables(httpClient, shopId);
            
            _context.Currencies.RemoveRange(_context.Currencies);
            _context.Currencies.AddRange(currencies);
            _context.SaveChanges();
            rawSellables.ForEach(s => s.Price.Currency = _context.Currencies.FirstOrDefault(c => c.SpreadShirtOldId == s.Price.CurrencyIdRaw));

            var sellables = rawSellables.Select(s => s.toSellable());
            _context.Sellables.RemoveRange(_context.Sellables);
            _context.Sellables.AddRange(sellables);
            _context.SaveChanges();

            return "Ok";
        }

        private Task<List<RawSellable>> RetrieveSellables(HttpClient httpClient, string shopId)
        {
            return httpClient.GetAsync($"shops/{shopId}/sellables")
                .ContinueWith(res =>
                {
                    var response = res.Result;
                    if (!response.IsSuccessStatusCode) return null;

                    var result = response.Content.ReadAsStringAsync().Result;
                    var rawSellables = JsonConvert.DeserializeObject<SellablesPages>(result);
                    return rawSellables?.Sellables;
                }); // Blocking call! Program will wait here until a response is received or a timeout occurs.
        }

        private Task<IEnumerable<Currency>> RetrieveCurrencies(HttpClient httpClient)
        {
            return httpClient.GetAsync("currencies?mediaType=json")
                .ContinueWith(res =>
            {
                var response = res.Result;
                if (!response.IsSuccessStatusCode) return null;

                var result = response.Content.ReadAsStringAsync().Result;
                var retrievedCurrencies = JsonConvert.DeserializeObject<CurrencyList>(result);

                var c = retrievedCurrencies?.Currencies.Select(currency =>
                {
                    var r = httpClient.GetAsync($"currencies/{currency.Id}?mediaType=json").Result;
                    var z = JsonConvert.DeserializeObject<Currency>(r.Content.ReadAsStringAsync().Result);
                    z.SpreadShirtOldId = z.Id;
                    z.Id = 0;
                    return z;
                });

                return c;
            });
        }

        // GET: api/Sellables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sellable>> GetSellable(string id)
        {
            var sellable = await _context.Sellables.FindAsync(id);

            if (sellable == null)
            {
                return NotFound();
            }

            return sellable;
        }

        // PUT: api/Sellables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellable(string id, Sellable sellable)
        {
            if (id != sellable.SellableId)
            {
                return BadRequest();
            }

            _context.Entry(sellable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellableExists(id))
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

        // POST: api/Sellables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sellable>> PostSellable(Sellable sellable)
        {
            _context.Sellables.Add(sellable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SellableExists(sellable.SellableId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSellable", new { id = sellable.SellableId }, sellable);
        }

        // DELETE: api/Sellables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellable(string id)
        {
            var sellable = await _context.Sellables.FindAsync(id);
            if (sellable == null)
            {
                return NotFound();
            }

            _context.Sellables.Remove(sellable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellableExists(string id)
        {
            return _context.Sellables.Any(e => e.SellableId == id);
        }
    }
}
