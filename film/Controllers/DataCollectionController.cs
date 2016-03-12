using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;
using film.Models;

namespace film.Controllers
{
    public class DataCollectionController : Controller
    {
        public async void UpdateFilmData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(
                "http://www.boxofficemojo.com/schedule/?view=bydate&release=theatrical&yr=2016&p=.htm"
            );

            HttpContent responseContent = response.Content;

            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
            {
                Console.WriteLine(await reader.ReadToEndAsync());
            }
       }
    }
}