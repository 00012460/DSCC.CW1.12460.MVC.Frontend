using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        //Hosted web API REST Service base url
        string Baseurl = "http://ec2-51-20-189-9.eu-north-1.compute.amazonaws.com";
        // GET: BookController Get all books list from Microservice API
        public async Task<ActionResult> Index()
        {
            List<Book> BooksList = new List<Book>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/book");

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Books list
                    BooksList = JsonConvert.DeserializeObject<List<Book>>(PrResponse);
                }
                //returning the Books list to view
                return View(BooksList);
            }
        }

        // GET: BookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var book = new Book();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync($"api/Book/{id}");

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Book
                    book = JsonConvert.DeserializeObject<Book>(PrResponse);
                }

                //returning the Book to view
                return View(book);
            }
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                // Changing header to application/json
                client.DefaultRequestHeaders.Clear();

                var applicationJson = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(applicationJson));

                // Sending Async POST request by serializing the object to JSON and storing Response
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Book", book);


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Error");
            }
        }

        // GET: BookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var book = new Book();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync($"api/Book/{id}");

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    book = JsonConvert.DeserializeObject<Book>(PrResponse);
                }

                //returning the Product list to view
                return View(book);
            }
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var applicationJson = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(applicationJson));


                // Sending Async PUT request to API and getting response of it
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Book/{id}", book);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Error");
            }

        }

        // GET: BookController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var book = new Book();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync($"api/Book/{id}");

                //Checking the response is successful or not which is sent HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var PrResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing the Product list
                    book = JsonConvert.DeserializeObject<Book>(PrResponse);
                }

                //returning the Product list to view
                return View(book);
            }
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                var applicationJson = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(applicationJson));


                // Sending Async DELETE request to API and getting response of it
                HttpResponseMessage response = await client.DeleteAsync($"api/Book/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Error");
            }

        }
    }
}
