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
                .Include(x=> x.Appearances)
                .Include(x=> x.ProductType)
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

            //_context.Database.ExecuteSqlRaw("Delete from [Sellables]");
            _context.Colors.RemoveRange(_context.Colors);
            _context.PrintTypes.RemoveRange(_context.PrintTypes);
            _context.Appearances.RemoveRange(_context.Appearances);
            _context.Sellables.RemoveRange(_context.Sellables);
            _context.Tags.RemoveRange(_context.Tags);
            _context.CurrencyPrices.RemoveRange(_context.CurrencyPrices);
            _context.ImageModels.RemoveRange(_context.ImageModels);
            _context.Currencies.RemoveRange(_context.Currencies);
            _context.Countries.RemoveRange(_context.Countries);
            _context.Languages.RemoveRange(_context.Languages);
            _context.Lengths.RemoveRange(_context.Lengths);
            _context.ProductTypes.RemoveRange(_context.ProductTypes);
            _context.ProductTypePrices.RemoveRange(_context.ProductTypePrices);
            _context.WashingInstructions.RemoveRange(_context.WashingInstructions);
            _context.Resources.RemoveRange(_context.Resources);
            _context.WashingInstructions.RemoveRange(_context.WashingInstructions);
            _context.Measures.RemoveRange(_context.Measures);
            _context.MeasureValues.RemoveRange(_context.MeasureValues);
            _context.Sizes.RemoveRange(_context.Sizes);
            _context.StockStates.RemoveRange(_context.StockStates);
            _context.ShippingStates.RemoveRange(_context.ShippingStates);
            _context.ShippingCountries.RemoveRange(_context.ShippingCountries);
            _context.SaveChanges();

            var currencies =  (await RetrieveCurrencies(httpClient)).ToList();
           
            _context.Currencies.AddRange(currencies);
            _context.SaveChanges();
            

            var languages = (await RetrieveLanguages(httpClient)).ToList();
            _context.Languages.AddRange(languages);
            _context.SaveChanges();

            var countries = (await RetrieveCountries(httpClient)).ToList();
            

            var lengths = countries.Select(c => c.Length).DistinctBy(x => x.Unit).ToList();
            _context.Lengths.AddRange(lengths);
            _context.SaveChanges();

            countries.ForEach(country => country.Length = _context.Lengths.Find(country.Length.Unit));
            countries.ForEach(country => country.Currency = _context.Currencies.Find(country.Currency.Id));
            countries.ForEach(country => country.DefaultLanguage = _context.Languages.Find(country.DefaultLanguage.Id));

            _context.Countries.AddRange(countries);
            _context.SaveChanges();

            var productTypes = (await RetrieveProductTypes(httpClient,shopId)).ToList();
            var washingInstructions = productTypes.SelectMany(pt => pt.WashingInstructions).DistinctBy(wi=> wi.Id).ToList();
            _context.WashingInstructions.AddRange(washingInstructions);
            _context.SaveChanges();

            var shippingCountries = productTypes.Select(pt => pt.ManufacturingCountry).DistinctBy(x=> x.Id).ToList();
            _context.ShippingCountries.AddRange(shippingCountries);
            _context.SaveChanges();

            productTypes.ForEach(productType=> productType.Price.Currency = _context.Currencies.Find(productType.Price.Currency.Id));
            productTypes.ForEach(pt=> pt.ManufacturingCountry = _context.ShippingCountries.Find(pt.ManufacturingCountry.Id));
            productTypes.ForEach(pt=> pt.WashingInstructions = pt.WashingInstructions.Select(washingInstruction => _context.WashingInstructions.Find(washingInstruction.Id)).ToList());
            var appearances = productTypes.SelectMany(pt => pt.Appearances).DistinctBy(ap=> ap.Id).ToList();

            var printTypes = appearances.SelectMany(a => a.PrintTypes).DistinctBy(printType=> printType.Id);
            _context.PrintTypes.AddRange(printTypes);
            _context.SaveChanges();
            appearances.ForEach(ap=> ap.PrintTypes = ap.PrintTypes.Select(pta=> _context.PrintTypes.Find(pta.Id)).ToList());

            var colors = appearances.SelectMany(a => a.Colors).DistinctBy(c => c.Value);
            _context.Colors.AddRange(colors);
            _context.SaveChanges();
            appearances.ForEach(ap => ap.Colors = ap.Colors.Select(c => _context.Colors.Find(c.Value)).ToList());

            var sizes = productTypes.SelectMany(pt => pt.Sizes).DistinctBy(x=> x.Id);
            _context.Sizes.AddRange(sizes);
            _context.SaveChanges();
            productTypes.ForEach(pt=> pt.Sizes = pt.Sizes.Select(s=> _context.Sizes.Find(s.Id)).ToList());

           
            _context.Appearances.AddRange(appearances);
            _context.SaveChanges();
            productTypes.ForEach(productType => productType.Appearances = productType.Appearances.Select(pta=> _context.Appearances.Find(pta.Id)).ToList());
            
            var stockStates = productTypes.SelectMany(pt => pt.StockStates).ToList();
            stockStates.ForEach(ss =>
            {
                ss.Appearance = _context.Appearances.Find(ss.Appearance.Id);
                ss.Size = _context.Sizes.Find(ss.Size.Id);
            });

            _context.StockStates.AddRange(stockStates);
            _context.SaveChanges();
            

            productTypes.ForEach(productType => productType.StockStates = productType.StockStates.Select(ss=> _context.StockStates.Find(ss.Id)).ToList());
            
            _context.ProductTypes.AddRange(productTypes);
            _context.SaveChanges();

            var rawSellables = await RetrieveSellables(httpClient, shopId);
            rawSellables.ForEach(s => s.Price.Currency = _context.Currencies.FirstOrDefault(c => c.Id == s.Price.CurrencyIdRaw));

            var sellables = rawSellables.Select(s => s.toSellable()).ToList();
            sellables.ForEach(s=> s.Appearances = s.Appearances.Select(ap=> _context.Appearances.Find(ap.Id)).ToList());
            sellables.ForEach(s=> s.ProductType = _context.ProductTypes.Find(s.ProductType.Id));
            _context.Sellables.AddRange(sellables);
            _context.SaveChanges();

            var productTypeDepartments = (await RetrieveProductTypeDepartments(httpClient,shopId)).ToList();
            var categories  = productTypeDepartments.SelectMany(ptd => ptd.Categories).ToList();
            categories.ForEach(c => c.ProductTypes=  c.ProductTypes.Select(pt => pt = _context.ProductTypes.Find(pt.Id)).ToList());


            _context.ProductTypeDepartments.AddRange(productTypeDepartments);
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
                    return JsonConvert.DeserializeObject<Currency>(r.Content.ReadAsStringAsync().Result);
                });

                return c;
            });
        }
        private Task<IEnumerable<Language>> RetrieveLanguages(HttpClient httpClient)
        {
            return httpClient.GetAsync("languages?mediaType=json")
                .ContinueWith(res =>
                {
                    var response = res.Result;
                    if (!response.IsSuccessStatusCode) return null;

                    var result = response.Content.ReadAsStringAsync().Result;
                    var retrievedLanguages = JsonConvert.DeserializeObject<LanguageList>(result);

                    var c = retrievedLanguages?.Languages.Select(currency =>
                    {
                        var r = httpClient.GetAsync($"languages/{currency.Id}?mediaType=json").Result;
                        return JsonConvert.DeserializeObject<Language>(r.Content.ReadAsStringAsync().Result);
                    });

                    return c;
                });
        }
        private Task<IEnumerable<Country>> RetrieveCountries(HttpClient httpClient)
        {
            return httpClient.GetAsync("countries?mediaType=json")
                .ContinueWith(res =>
                {
                    var response = res.Result;
                    if (!response.IsSuccessStatusCode) return null;

                    var result = response.Content.ReadAsStringAsync().Result;
                    var retrievedCountries = JsonConvert.DeserializeObject<CountriesList>(result);

                    var c = retrievedCountries?.Countries.Select(currency =>
                    {
                        var r = httpClient.GetAsync($"countries/{currency.Id}?mediaType=json").Result;
                        return JsonConvert.DeserializeObject<Country>(r.Content.ReadAsStringAsync().Result);
                    });

                    return c;
                });
        }
        private Task<IEnumerable<ProductType>> RetrieveProductTypes(HttpClient httpClient,string shopId)
        {
            return httpClient.GetAsync($"shops/{shopId}/productTypes?mediaType=json&fullData=true&limit=1000")
                .ContinueWith(res =>
                {
                    var response = res.Result;
                    if (!response.IsSuccessStatusCode) return null;

                    var result = response.Content.ReadAsStringAsync().Result;
                    var retrievedProductTypes = JsonConvert.DeserializeObject<ProductTypesList>(result);

                    var c = retrievedProductTypes?.ProductTypes.Select(productType =>
                    {
                        var r = httpClient.GetAsync($"shops/{shopId}/productTypes/{productType.Id}?mediaType=json").Result;
                        return JsonConvert.DeserializeObject<ProductType>(r.Content.ReadAsStringAsync().Result);
                    });

                    return c;
                });
        }

        private Task<List<ProductTypeDepartment>> RetrieveProductTypeDepartments(HttpClient httpClient, string shopId)
        {
            return httpClient.GetAsync($"shops/{shopId}/productTypeDepartments?mediaType=json&fullData=true")
                .ContinueWith(res =>
                {
                    var response = res.Result;
                    if (!response.IsSuccessStatusCode) return null;

                    var result = response.Content.ReadAsStringAsync().Result;
                    var rawProductTypeDepartmentList = JsonConvert.DeserializeObject<ProductTypeDepartmentList>(result);
                    return rawProductTypeDepartmentList?.ProductTypeDepartments;
                }); // Blocking call! Program will wait here until a response is received or a timeout occurs.
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
