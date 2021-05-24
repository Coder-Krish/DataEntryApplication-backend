using DataEntryApplication.DataAccess;
using DataEntryApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataEntryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            dataEntryDbContext.Add(labor);
            dataEntryDbContext.SaveChanges();

            var laborCollection = (from l in dataEntryDbContext.labors
                                   where l.isActive == true
                                   select l);

            return Ok(laborCollection);


        }

        // PUT api/<LaborController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Labor labor)
        {
            if (labor.laborName != null ||
                labor.country != null ||
                labor.district != null ||
                labor.taskDetail != null ||
                labor.workHours != 0)
            {
                var laborCollection = (from l in dataEntryDbContext.labors
                                       where l.isActive == true && l.id == id
                                       select l).FirstOrDefault();

                if (laborCollection != null)
                {
                    laborCollection.laborName = labor.laborName;
                    laborCollection.country = labor.country;
                    laborCollection.district = labor.district;
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
                return Ok("You need to provide all the details");
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
    }
}
