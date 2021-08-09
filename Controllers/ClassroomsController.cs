using Microsoft.AspNetCore.Mvc;
using SimpleSchoolAPI.Data_Access_Layer;
using SimpleSchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



//When trying the controllers on swagger... Run the post controller first, as the database is empty until data is Posted to the database 

namespace SimpleSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {

        //Injecting ApplicationDbContext and Classroom Model into the Controller
        public readonly ApplicationDbContext Db;

        public ClassroomsController(ApplicationDbContext db)
        {
            Db = db;
        }  

        // The get handler
        [HttpGet]
        public IActionResult Get()
        {

            // Get a list of all objects of the Classroom Model class
            IEnumerable<Classroom> classrooms = Db.Classrooms;


            //Return the List here
            return Ok(classrooms);
        }

        //The get by Id handler
        // GET api/<ClassroomsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            // Create a variable that gets the first object, that has the id that is being passed
            var classroom = Db.Classrooms.FirstOrDefault(x => x.ClassName == id);


            //return the variable
            return Ok(classroom);
        }


        //The POST Handler
        // POST api/<ClassroomsController>
        [HttpPost]
        public void Post(Classroom  value)
        {
            //Add the object to the db
            Db.Classrooms.Add(value);

            //save the changes made to the database
            Db.SaveChanges();
        }


        //The put Handler
        // PUT api/<ClassroomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            //Create a variable and assisgn it the value of the first object that has the same id as the one passed
            var classroom = Db.Classrooms.FirstOrDefault(x => x.Id == id);

            //Update the property or properrties you wish to update
            classroom.ClassName = "Basic 5";

            //update the database
            Db.Classrooms.Update(classroom);

            //save the changes made to the database
            Db.SaveChanges();
        }


        //The delete handler
        // DELETE api/<ClassroomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Create a variable and assisgn it the value of the first object that has the same id as the one passed
            var classroom = Db.Classrooms.FirstOrDefault(x => x.Id == id);

            //remove the object from the database
            Db.Classrooms.Remove(classroom);

            //save the changes made to the database
            Db.SaveChanges();
        }
    }
}



//When trying the controllers on swagger... Run the post controller first, as the database is empty until data is Posted to the database 