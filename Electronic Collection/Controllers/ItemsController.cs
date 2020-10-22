using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronic_Collection.Data;
using Electronic_Collection.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Electronic_Collection.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> GamesIndex()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.rawg.io/api/games");

            string obtainedFromFormOnView = "action";

            // HttpResponseMessage response = await client.GetAsync("?genres=" + obtainedFromFormOnView);
            HttpResponseMessage response = await client.GetAsync("");

            List<Item> itemsToChooseFrom = new List<Item>();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
                

                for (int i = 0; i < 10; i++)
                {
                    JToken name = jsonResults["results"][i]["name"];
                    JToken releaseDate = jsonResults["results"][i]["released"];

                    Item randomItem = new Item();
                    randomItem.Name = name.ToString();
                    randomItem.ReleaseDate = releaseDate.ToString();
                    


                    itemsToChooseFrom.Add(randomItem);
                }
            }

            return View(itemsToChooseFrom);
        }

        public ActionResult SearchByTitle()
        {
            TitleInput input = new TitleInput();

            return View(input);
        }


        [HttpPost]
        public async Task<ActionResult> SearchByTitle(TitleInput titleInput)
        {
            // make another games API call
            // call for Games, with a title of 'titleToSearchBy'
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.rawg.io/api/games");

            HttpResponseMessage response = await client.GetAsync("?search=" + titleInput.TitleToSearchBy);

            List<Item> itemsToChooseFrom = new List<Item>();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);


                for (int i = 0; i < 10; i++)
                {
                    JToken name = jsonResults["results"][i]["name"];
                    JToken releaseDate = jsonResults["results"][i]["released"];

                    Item randomItem = new Item();
                    randomItem.Name = name.ToString();
                    randomItem.ReleaseDate = releaseDate.ToString();


                    itemsToChooseFrom.Add(randomItem);
                }
            }

            return View("GamesIndex", itemsToChooseFrom);
        }

        [HttpPost]
        public async Task<ActionResult> SearchByReleaseDate(DateInput dateInput)
        {
            // make another games API call
            // call for Games, with a title of 'titleToSearchBy'
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.rawg.io/api/games");

            HttpResponseMessage response = await client.GetAsync("?search=" + dateInput.DateToSearchBy);

            List<Item> itemsToChooseFrom = new List<Item>();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);


                for (int i = 0; i < 10; i++)
                {
                    JToken name = jsonResults["results"][i]["name"];
                    JToken releaseDate = jsonResults["results"][i]["released"];

                    Item randomItem = new Item();
                    randomItem.Name = name.ToString();
                    randomItem.ReleaseDate = releaseDate.ToString();
                    


                    itemsToChooseFrom.Add(randomItem);
                }
            }

            return View("GamesIndex", itemsToChooseFrom);
        }

        public ActionResult SearchByReleaseDate()
        {
            DateInput input = new DateInput();

            return View(input);
        }

        [HttpPost]
        public async Task<ActionResult> SearchByGenre(GenreObj genreObj)
        {
            // make another games API call
            // call for Games, with a title of 'titleToSearchBy'
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.rawg.io/api/genres");

            HttpResponseMessage response = await client.GetAsync("?search=" + genreObj.Title);

            List<Item> itemsToChooseFrom = new List<Item>();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);


                for (int i = 0; i < 10; i++)
                {
                    JToken name = jsonResults["results"][i]["name"];
                    JToken releaseDate = jsonResults["results"][i]["released"];
                    //JToken genreObj = jsonResults["results"][i]["released"];

                    Item randomItem = new Item();
                    randomItem.Name = name.ToString();
                    randomItem.ReleaseDate = releaseDate.ToString();
                    //randomItem.GenreObj = new GenreObj();
                    //randomItem.GenreObj.Title = genreObj.ToString();


                    itemsToChooseFrom.Add(randomItem);
                }
            }

            return View("GamesIndex", itemsToChooseFrom);
        }

        public ActionResult SearchByGenre()
        {
            GenreObj input = new GenreObj();

            return View(input);
        }

        [HttpPost]
        public async Task<ActionResult> SearchByTags(TypeObj typeObj)
        {
            // make another games API call
            // call for Games, with a title of 'titleToSearchBy'
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.rawg.io/api/tags");

            HttpResponseMessage response = await client.GetAsync("?search=" + typeObj.TypeTitle);

            List<Item> itemsToChooseFrom = new List<Item>();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);


                for (int i = 0; i < 10; i++)
                {
                    JToken name = jsonResults["results"][i]["name"];
                    JToken releaseDate = jsonResults["results"][i]["released"];
                    //JToken genreObj = jsonResults["results"][i]["released"];

                    Item randomItem = new Item();
                    randomItem.Name = name.ToString();
                    randomItem.ReleaseDate = releaseDate.ToString();
                    //randomItem.GenreObj = new GenreObj();
                    //randomItem.GenreObj.Title = genreObj.ToString();


                    itemsToChooseFrom.Add(randomItem);
                }
            }

            return View("GamesIndex", itemsToChooseFrom);
        }

        public ActionResult SearchByTags()
        {
            TypeObj input = new TypeObj();

            return View(input);
        }


        public async Task<IActionResult> PlatformIndex()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.rawg.io/api/platforms");

            HttpResponseMessage response = await client.GetAsync("");

            List<Item> itemsToChooseFrom = new List<Item>();

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);


                for (int i = 0; i < 10; i++)
                {
                    JToken name = jsonResults["results"][i]["name"];

                    Item randomItem = new Item();
                    randomItem.Name = name.ToString();

                    itemsToChooseFrom.Add(randomItem);
                }
            }

            return View(itemsToChooseFrom);
        }
        public ActionResult SearchByPlatform()
        {
            return View();
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Name == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Type,Genre,ReleaseDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Type,Genre,ReleaseDate")] Item item)
        {
            if (id != item.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Name == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(string id)
        {
            return _context.Item.Any(e => e.Name == id);
        }
    }
}
