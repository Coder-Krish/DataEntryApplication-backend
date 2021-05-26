using DataEntryApplication.DataAccess;
using DataEntryApplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataEntryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("DataEntryApplicationPolicy")]
    public class DistrictController : ControllerBase
    {
        private DataEntryDbContext dataEntryDbContext = new DataEntryDbContext();

        // GET: api/<DistrictController>
        [HttpGet]
        public IActionResult Get()
        {
            var districtCollection = (from d in dataEntryDbContext.districts
                                      where d.isActive == true
                                      //d.labor.isActive == true
                                      select d)
                                           .Include(l => l.labor);

            return Ok(districtCollection);
        }

        // GET api/<DistrictController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var districtCollection = (from d in dataEntryDbContext.districts
                                      where d.isActive == true && d.id == id
                                      select d)
                                      .Include(l => l.labor)
                                      .FirstOrDefault();
            if (districtCollection != null)
            {
                return Ok(districtCollection);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Sorry No Data Found");
            }
        }

        [Route("~/api/getDistrictsById/{id:int}")]
        [HttpGet]
        public IActionResult GetDistrictsByCountryId(int id)
        {
            var districtCollection = (from d in dataEntryDbContext.districts
                                      where d.countryId == id && d.isActive == true
                                      select d).Include(l => l.labor);

            if (districtCollection != null)
            {
                return Ok(districtCollection);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Sorry no data found");
            }

           
        }

        // POST api/<DistrictController>
        [HttpPost]
        public IActionResult Post([FromBody] District district)
        {
            var context = new ValidationContext(district, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(district, context, result, true);
            if(result.Count() == 0)
            {
                dataEntryDbContext.Add(district);
                dataEntryDbContext.SaveChanges();

                var districtCollection = (from d in dataEntryDbContext.districts
                                          where d.isActive == true
                                          select d)
                                          .Include(l => l.labor);
                return Ok(districtCollection);
            }
            else
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                  result);
            }
        }

            

        // PUT api/<DistrictController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] District district)
        {


            var context = new ValidationContext(district, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(district, context, result, true);
            if (result.Count() == 0)
            {

                var districtCollection = (from d in dataEntryDbContext.districts
                                         where d.id == id && d.isActive == true
                                         select d).FirstOrDefault();
                if (districtCollection != null)
                {
                    districtCollection.name = district.name;
                    districtCollection.code = district.code;
                    districtCollection.countryId = district.countryId;
                    districtCollection.laborRatePerHour = district.laborRatePerHour;
                    dataEntryDbContext.SaveChanges();
                    return Ok(districtCollection);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                  "Sorry Cannot Update");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 result);
            }
           
        }

        // DELETE api/<DistrictController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var districtCollection = (from d in dataEntryDbContext.districts
                                      where d.isActive == true && d.id == id
                                      select d).FirstOrDefault();
            if (districtCollection != null)
            {
                districtCollection.isActive = false;
                dataEntryDbContext.SaveChanges();

                var data = (from d in dataEntryDbContext.districts
                            where d.isActive == true
                            select d);
                return Ok(data);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
               "Sorry Cannot Delete");
            }

        }
        [Route("~/api/countDistricts")]
        [HttpGet]
        public IActionResult CountDistricts()
        {
            var districtCollection = (from c in dataEntryDbContext.districts
                                     where c.isActive == true
                                     select c);

            var countOfDistrict = districtCollection.Count();
            return Ok(countOfDistrict);
        }
    }
}
