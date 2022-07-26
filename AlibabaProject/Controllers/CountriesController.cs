using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AlibabaProject.Services;
using AlibabaProject.Models;
using RestSharp;

namespace AlibabaProject.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LightHomePage()
        {
            return View();
        }
        public ActionResult DarkHomePage()
        {
            return View();
        }
        public ActionResult DarkDetail()
        {
            Country country = TempData["CountryByNameList"] as Country;
            return PartialView(country);
        }


        public async Task<ActionResult> GetAllData()
        {
            List<Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();
            TempData["CountryList"] = countries.OrderBy(o=>o.Name).OrderBy(o=>o.Population).ToList();
            //return RedirectToAction("_CountrySection");
            return Json(countries, "application/json", JsonRequestBehavior.AllowGet);

        }
        public ActionResult _CountrySection()
        {
            var list = TempData["CountryList"];
            List<Country> countryList = TempData["CountryList"] as List<Country>;
            return PartialView(countryList);
        }
        public ActionResult _CountrySectionDark()
        {
            var list = TempData["CountryList"];
            List<Country> countryList = TempData["CountryList"] as List<Country>;
            return PartialView(countryList);
        }
        public async Task<ActionResult> GetByName(string name)
        {
            Country country = await RESTCountriesAPI.GetCountryByFullNameAsync(name);
            TempData["CountryByNameList"] = country;
            return RedirectToAction("LightDetail");

        }
        public async Task<ActionResult> GetByNameDark(string name)
        {
            Country country = await RESTCountriesAPI.GetCountryByFullNameAsync(name);
            TempData["CountryByNameList"] = country;
            return RedirectToAction("DarkDetail");

        }
        public ActionResult LightDetail()
        {
            Country country = TempData["CountryByNameList"] as Country;
            return PartialView(country);
        }

        public async Task<ActionResult> GetCountryByName(string name)
        {
            List<Country> countries = new List<Country>();
            if (string.IsNullOrEmpty(name))
            {
                 countries = await RESTCountriesAPI.GetAllCountriesAsync();
            }
            else
            {
                countries = await RESTCountriesAPI.GetCountriesByNameContainsAsync(name);
            }
            
            TempData["CountryList"] = countries.OrderBy(o => o.Name).OrderBy(o => o.Population).ToList(); 
            return Json(countries, "application/json", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetCountryByRegion(string region)
        {
            List<Country> countries = await RESTCountriesAPI.GetAllCountriesAsync();

            var list = countries.Where(o => o.Region == region).ToList();



            TempData["CountryList"] = list.OrderBy(o => o.Name).OrderBy(o => o.Population).ToList();
            return Json(list, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}