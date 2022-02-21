using Blog_NTierArchitect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blog_NTierArchitect.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var url = _configuration.GetSection("MyAPI").GetSection("URL").Value;
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(jsonString);
            return View(values);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            var url = _configuration.GetValue<string>("MyAPI:URL");
            var httpclient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PostAsync(url + "api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _configuration.GetValue<string>("MyAPI:URL");
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<EmployeeViewModel>(jsonEmployee);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,EmployeeViewModel employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }
            var url = _configuration.GetValue<string>("MyAPI:URL");
            var httpclient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpclient.PutAsync(url + "api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _configuration.GetValue<string>("MyAPI:URL");
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.DeleteAsync(url + "api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
