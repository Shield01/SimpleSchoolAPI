using Microsoft.AspNetCore.Mvc;
using SimpleSchoolAPI.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleSchoolAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



//When trying the controllers on swagger... Run the post controller first, as the database is empty until data is Posted to the database


namespace SimpleSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {

        //Because we will be working with the database, we need to inject the ApplicationDbContext as a depency

        public readonly ApplicationDbContext Db;
        public TeachersController(ApplicationDbContext db)
        {
            Db = db;
        }

        //The get handler, this returns a list of all teachers, along with their properties
        // GET: api/<TeachersController>
        [HttpGet]
        public IActionResult Get()
        {
            //Get a list of all objects of the Teacher class 
            IEnumerable<Teacher> teachers = Db.Teachers;

            //return the list
            return Ok(teachers);
        }

        //the get by id handler
        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //get the object that has the same id as that which is passed and assign it to a variable
            var teacher = Db.Teachers.FirstOrDefault(x => x.Id == id);

            //return the variable
            return Ok(teacher);
        }

        //the Post handler, this adds an object to the database
        // POST api/<TeachersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //create an object of the teacher class
            //Teacher FirstTeacher = new Teacher
            Teacher teacher = new Teacher
            {
                //assign the properties to the new object
                Id = 01,
                TeachersLastName = "Lamido",
                TeachersFirstName = "Sanusi",
                TeachersQualification = "B.sc",
                MaritalStatus = "Single",
                Salary = "40,000", 
            };

            

            //add the new object to the database
            Db.Teachers.Add(teacher);

            //save the changes made to the database;
            Db.SaveChanges();

        }


        //the PUT handler
        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //get the object that wants to be updated
            var teacher = Db.Teachers.FirstOrDefault(x => x.Id == id);

            //alter the value you wish to change
            teacher.Salary = "50,000";

            //update the changes to the database
            Db.Teachers.Update(teacher);

            //save the changes made
            Db.SaveChanges();
        }


        //the delete handler
        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //get the object that you want to delete
            var teacher = Db.Teachers.FirstOrDefault(x => x.Id == id);

            // delete the object
            Db.Teachers.Remove(teacher);

            //save the changes made to the database
            Db.SaveChanges();
        }
    }
}



//When trying the controllers on swagger... Run the post controller first, as the database is empty until data is Posted to the database