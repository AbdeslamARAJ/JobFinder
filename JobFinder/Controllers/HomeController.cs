using JobFinder.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobFinder.Controllers
{
    public class HomeController : Controller
    {
        private string BASE_URL = "https://jobs.github.com/positions.json";
        public async Task<IActionResult> Index()
        {
            string url = BASE_URL + "?search=trend";
            return View(await GetJobs(url));
        }

        [Route("search")]
        public async Task<IActionResult> Search()
        {
            string position = HttpContext.Request.Query["position"].ToString();
            string location = HttpContext.Request.Query["location"].ToString();

            string url = BASE_URL;

            if (location.Length > 0)
            {
                url += "?location=" + location;
            }
            if (position.Length > 0)
            {
                url += "?search=" + position;
            }
            return View(await GetJobs(url));
        }

        private async Task<List<Job>> GetJobs(string url)
        {
            List<Job> jobs = new List<Job>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string result = await response.Content.ReadAsStringAsync();
                    jobs = JsonConvert.DeserializeObject<List<Job>>(result);
                }
            }
            return jobs;
        }
    }
}
