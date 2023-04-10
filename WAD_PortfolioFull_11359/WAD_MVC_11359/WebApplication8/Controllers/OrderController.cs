using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WAD_MVC_11359.Models;

namespace WAD_MVC_11359.Controllers
{
    public class OrderController : Controller
    {
        // The Definition of Base URL
        public const string baseUrl = "http://localhost:62161/";
        Uri ClientBaseAddress = new Uri(baseUrl);
        HttpClient clnt;


        // Constructor for initiating request to the given base URL publicly
        public OrderController()
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
            List<Order> ProductInfo = new List<Order>();


            HeaderClearing();

            // Sending Request to the find web api Rest service resources using HTTPClient
            HttpResponseMessage httpResponseMessage = await clnt.GetAsync("api/Order");

            // If the request is success
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                // storing the web api data into model that was predefined prior
                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;

                ProductInfo = JsonConvert.DeserializeObject<List<Order>>(responseMessage);
            }
            return View(ProductInfo);

        }



        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            //Creating a Get Request to get single Product
            Order orderDetails = new Order();

            HeaderClearing();

            // Creating a get request after preparation of get URL and assignin the results

            HttpResponseMessage httpResponseMessageDetails = clnt.GetAsync(clnt.BaseAddress + "api/Order/" + id).Result;

            // Checking for response state
            if (httpResponseMessageDetails.IsSuccessStatusCode)
            {
                // storing the response details received from web api 
                string detailsInfo = httpResponseMessageDetails.Content.ReadAsStringAsync().Result;

                // deserializing the response
                orderDetails = JsonConvert.DeserializeObject<Order>(detailsInfo);
            }
            return View(orderDetails);
        }



        // GET: Order/Create
        public async Task<ActionResult> CreateAsync()
        {
            List<Customer> customers = new List<Customer>();
            HeaderClearing();
            HttpResponseMessage httpResponseMessage = await clnt.GetAsync("api/Order");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(responseMessage);
            }

            var viewModel = new CustomerOrderViewModel
            {
                Order = new Order(),
                Customer = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(customers, "ID", "Name", "CustomerAddress")
            };
            return View(viewModel);
        }


        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            order.Customer = new Customer { ID = order.Customer.ID };
            if (ModelState.IsValid)
            {
                string createOrderInfo = JsonConvert.SerializeObject(order);
                StringContent stringContentInfo = new StringContent(createOrderInfo, Encoding.UTF8, "application/json");
                HttpResponseMessage createHttpResponseMessage = clnt.PostAsync(clnt.BaseAddress + "api/Order", stringContentInfo).Result;
                if (createHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Order order = new Order();
            HeaderClearing();

            HttpResponseMessage httpResponseMessage = await clnt.GetAsync($"api/Order/{id}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(responseMessage);
            }

            List<Customer> customers = new List<Customer>();
            httpResponseMessage = await clnt.GetAsync("api/Customer");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(responseMessage);
            }
            var viewModel = new CustomerOrderViewModel
            {
                Order = order,
                Customer = new SelectList(customers, "Id", "CustomerName", "Description")
            };
            return View(viewModel);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            order.Customer = new Customer { ID = order.Customer.ID };

            if (ModelState.IsValid)
            {
                string createOrderInfo = JsonConvert.SerializeObject(order);
                StringContent stringContentInfo = new StringContent(createOrderInfo, Encoding.UTF8, "application/json");
                HttpResponseMessage editHttpResponseMessage = clnt.PutAsync(clnt.BaseAddress + $"api/Order/{id}", stringContentInfo).Result;
                if (editHttpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(order);
        }

        // GET: ProgressController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Order orderDetails = new Order();
            HeaderClearing();
            HttpResponseMessage response = await clnt.GetAsync(clnt.BaseAddress + "api/Order/" + id);

            if (response.IsSuccessStatusCode)
            {
                string detailsInfo = response.Content.ReadAsStringAsync().Result;

                orderDetails = JsonConvert.DeserializeObject<Order>(detailsInfo);
            }
            return View(orderDetails);
        }

        // POST: ProgressController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await clnt.DeleteAsync(clnt.BaseAddress + "api/Order/" + id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}