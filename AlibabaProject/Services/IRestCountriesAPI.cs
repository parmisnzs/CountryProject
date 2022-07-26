using AlibabaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AlibabaProject.Services
{
    public interface IRestCountriesAPI 
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<List<Country>> GetCountriesByNameContainsAsync(string name);
        Task<Country> GetCountryByFullNameAsync(string fullName);
    }
}