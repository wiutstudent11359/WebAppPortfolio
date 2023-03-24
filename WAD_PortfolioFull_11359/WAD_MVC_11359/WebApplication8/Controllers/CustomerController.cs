using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using WAD_MVC_11359.Models;

namespace WAD_MVC_11359.Controllers
{
    public class CustomerController : Controller
    {
        // The Definition of Base URL
        public const string baseUrl = "http://localhost:62161/";
        Uri ClientBaseAddress = new Uri(baseUrl);
        HttpClient clnt;


        // Constructor for initiating request to the given base URL publicly
        public CustomerController()
        {
            clnt = new HttpClient();
            clnt.BaseAddress = ClientBaseAddress;

        }

        public void HeaderClearing()
        {
            // Clearing default headers
            clnt.DefaultRequestHeaders.Clear();

            // Define the request type of the data
            clnt.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: Order
        public async Task<ActionResult> Index()
        {


            //// Creating the list of new Orders list
            List<Customer> OrderInfo = new List<Customer>();


            HeaderClearing();

            // Sending Request to the find web api Rest service resources using HTTPClient
            HttpResponseMessage httpResponseMessage = await clnt.GetAsync("api/Customer");

            // If the request is success
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                // storing the web api data into model that was predefined prior
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;

                OrderInfo = JsonConvert.DeserializeObject<List<Customer>>(responseMessage);
            }
            return View(OrderInfo);

        }



        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            //Creating a Get Request to get single Order
            Customer customerDetails = new Customer();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = clnt.GetAsync(clnt.BaseAddress + "api/Customer/" + id).Result;

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                customerDetails = JsonConvert.DeserializeObject<Customer>(detailsInfo);
            }
            return View(customerDetails);
        }



        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            // Order.Customer = new Customer { ID = Order.OrderCustomerId };
            if (ModelState.IsValid)
            {
                // serializing Order object into json format to send
                /*string jsonObject = "{"+Order."}"*/
                ;
                string createOrderInfo = JsonConvert.SerializeObject(customer);

                // creating string content to pass as Http content later
                StringContent stringContentInfo = new StringContent(createOrderInfo, Encoding.UTF8, "application/json");

                // Making a Post request
                HttpResponseMessage createHttpResponseMessage = clnt.PostAsync(clnt.BaseAddress + "api/Customer/", stringContentInfo).Result;
                if (createHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(customer);

        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgressController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Customer customerDetails = new Customer();
            HeaderClearing();
            HttpResponseMessage response = await clnt.GetAsync(clnt.BaseAddress + "api/Customer/" + id);

            if (response.IsSuccessStatusCode)
            {
                string detailsInfo = response.Content.ReadAsStringAsync().Result;

                customerDetails = JsonConvert.DeserializeObject<Customer>(detailsInfo);
            }
            return View(customerDetails);
        }

        // POST: ProgressController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await clnt.DeleteAsync(clnt.BaseAddress + "api/Customer/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}