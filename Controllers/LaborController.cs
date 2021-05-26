using DataEntryApplication.DataAccess;
using DataEntryApplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class LaborController : ControllerBase
    {
        private DataEntryDbContext dataEntryDbContext = new DataEntryDbContext();
        // GET: api/<LaborController>
        [HttpGet]
        public IActionResult Get()
        {
            var laborCollection = (from l in dataEntryDbContext.labors
                                   where l.isActive == true
                                   select l);

            return Ok(laborCollection);

        }

        // GET api/<LaborController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var laborCollection = (from l in dataEntryDbContext.labors
                                   where l.isActive == true && l.id == id
                                   select l);
            if (laborCollection != null)
            {
                return Ok(laborCollection);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Sorry No Data Found");
            }
          

        }

        // POST api/<LaborController>
        [HttpPost]
        public IActionResult Post([FromBody] Labor labor)
        {
            var context = new ValidationContext(labor, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(labor, context, result, true);
            if (result.Count() == 0)
            {
                dataEntryDbContext.Add(labor);
                dataEntryDbContext.SaveChanges();

                var laborCollection = (from l in dataEntryDbContext.labors
                                       where l.isActive == true
                                       select l);

                return Ok(laborCollection);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 result);
            }

        }

        // PUT api/<LaborController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Labor labor)
        {



            var context = new ValidationContext(labor, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(labor, context, result, true);
            if (result.Count() == 0)
            {
                var laborCollection = (from l in dataEntryDbContext.labors
                                       where l.isActive == true && l.id == id
                                       select l).FirstOrDefault();

                if (laborCollection != null)
                {
                    laborCollection.laborName = labor.laborName;
                    laborCollection.districtId = labor.districtId;
                    laborCollection.taskDetail = labor.taskDetail;
                    laborCollection.workHours = labor.workHours;

                    dataEntryDbContext.SaveChanges();

                    return Ok(laborCollection);

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Sorry Cannot update");
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  result);
            }
        }

        // DELETE api/<LaborController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var laborCollection = (from l in dataEntryDbContext.labors
                                   where l.isActive == true && l.id == id
                                   select l).FirstOrDefault();
            if (laborCollection != null)
            {
                laborCollection.isActive = false;
                dataEntryDbContext.SaveChanges();

                var data = (from l in dataEntryDbContext.labors
                            where l.isActive == true
                            select l);
                return Ok(data);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Sorry Cannot Delete");
            }
        }

        [Route("~/api/countLabors")]
        [HttpGet]
        public IActionResult CountLabors()
        {
            var laborCollection = (from c in dataEntryDbContext.labors
                                      where c.isActive == true
                                      select c);

            var countOfLabor = laborCollection.Count();
            return Ok(countOfLabor);
        }
    }
}
