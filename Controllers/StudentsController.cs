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
    public class StudentsController : ControllerBase
    {

        //Injecting ApplicationDbContext and Classroom Model into the Controller
        public readonly ApplicationDbContext Db;

        public StudentsController(ApplicationDbContext db)
        {
            Db = db;
        }


        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult Get()
        {
            // Get a list of all objects of the Student Model class
            IEnumerable<Student> students = Db.Students;

            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Create a variable that gets the first object, that has the id that is being passed
            var student = Db.Students.FirstOrDefault(x => x.Id == id);

            //return the variable
            return Ok(student);
        }


        // POST api/<StudentsController>
        [HttpPost]
        public void Post(Student value)
        {
            Db.Students.Add(value);

            //save the changes made to the database
            Db.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //Create a variable and assisgn it the value of the first object that has the same id as the one passed
            var student = Db.Students.FirstOrDefault(x => x.Id == id);

            //Update the property or properrties you wish to update
            student.Age = 18;

            //update the database
            Db.Students.Update(student);

            //save the changes made to the database
            Db.SaveChanges();
        }

        //The delete handler
        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Create a variable and assisgn it the value of the first object that has the same id as the one passed
            var student = Db.Students.FirstOrDefault(x => x.Id == id);

            //remove the object from the database
            Db.Students.Remove(student);

            //save the changes made to the database
            Db.SaveChanges();
        }
    }
}


//When trying the controllers on swagger... Run the post controller first, as the database is empty until data is Posted to the database 
