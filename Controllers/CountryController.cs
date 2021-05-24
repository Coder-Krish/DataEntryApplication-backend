using DataEntryApplication.DataAccess;
using DataEntryApplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataEntryApplication.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("DataEntryApplicationPolicy")]
    public class CountryController : ControllerBase
    {

        private DataEntryDbContext dataEntryDbContext = new DataEntryDbContext();

        // GET: api/<CountryController>
        [HttpGet]
        public IActionResult Get()
        {
            var countryCollection = (from c in dataEntryDbContext.countries
                                     
                                     where c.isActive == true
                                     select c).Include(d => d.district);
            return Ok(countryCollection);
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var countryCollection = (from c in dataEntryDbContext.countries
                                     where c.id == id && c.isActive == true
                                     select c).Include(d => d.district).FirstOrDefault();
            if (countryCollection != null)
            {
                return Ok(countryCollection);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Sorry No Data Found");
            }
        }

        // POST api/<CountryController>
        [HttpPost]
        public IActionResult Post([FromBody] Country country)
        {
            dataEntryDbContext.Add(country);
            dataEntryDbContext.SaveChanges();
            

            var countryCollection = (from c in dataEntryDbContext.countries
                                     where c.isActive == true
                                     select c);

            return Ok(countryCollection);

        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Country country)
        {
            if (country.name == null || country.code == null)
            {
                return Ok("You have to provide all the details");
            }
            else
            {
                var countryCollection = (from c in dataEntryDbContext.countries
                                         where c.id == id && c.isActive == true
                                         select c).Include(d => d.district).FirstOrDefault();
                if (countryCollection != null)
                {
                    countryCollection.name = country.name;
                    countryCollection.code = country.code;
                    dataEntryDbContext.SaveChanges();
                    return Ok(countryCollection);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                  "Sorry Cannot Update");
                }
            }
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var countryCollection = (from c in dataEntryDbContext.countries
                                     where c.id == id && c.isActive == true
                                     select c).FirstOrDefault();
            if (countryCollection != null)
            {
                countryCollection.isActive = false;
                dataEntryDbContext.SaveChanges();

                var data = (from c in dataEntryDbContext.countries
                                         where c.isActive == true
                                         select c).Include(d => d.district);
                return Ok(data);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Sorry Cannot Delete");
            }
        }
    }
}
