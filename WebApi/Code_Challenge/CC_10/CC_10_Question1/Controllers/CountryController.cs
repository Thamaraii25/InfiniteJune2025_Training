using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC_10_Question1.Models;

namespace CC_10_Question1.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        static List<Country> countryList = new List<Country>()
        {
            new Country{Id=1, CountryName= "India", Capital = "NewDelhi"},
            new Country{Id=2, CountryName= "China", Capital = "Beijing"},
            new Country{Id=3, CountryName= "Bangladesh", Capital = "Dhaka"},
            new Country{Id=4, CountryName= "France", Capital = "Paris"},
            new Country{Id=5, CountryName= "UK", Capital = "London"}
        };

        [HttpGet]
        [Route("getAllCountry")]
        public IEnumerable<Country> Get()
        {
            return countryList;
        }

        [HttpPost]
        [Route("addCountry")]
        public List<Country> PostAll([FromBody] Country country)
        {
            countryList.Add(country);
            return countryList;
        }


        [HttpPut]
        [Route("updateCountry")]
        public IEnumerable<Country> Put(int id, [FromBody] Country country)
        {
            countryList[id - 1] = country;
            return countryList;
        }

        [HttpDelete]
        [Route("deleteCountry")]
        public IEnumerable<Country> Delete(int id)
        {
            countryList.RemoveAt(id - 1);
            return countryList;
        }
    }
}
