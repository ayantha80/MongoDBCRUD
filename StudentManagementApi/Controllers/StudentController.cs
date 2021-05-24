using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.DTO;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService iStudentService = null;
        public StudentController(IStudentService _iStudentService)
        {
            iStudentService = _iStudentService;
        }

        /// <summary>
        /// Select the student record by email.Mongo DB Indexes used.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Student record</returns>
        
        [HttpGet]
        [Route("Select/{email}")]
        public IActionResult Select(string email)
        {
            ResponseObject response = new ResponseObject();

            try
            {
                var result = iStudentService.Select(email);
                response.Data = result;

            }
            catch (Exception ex)
            {
                response.ErrorDescription = ex.Message;
            }

            return Ok(response);
        }


        /// <summary>
        /// Student record creation.MongoDB Transactions used.
        /// </summary>
        /// <param name="student">Student record</param>
        /// <returns></returns>
       
        [HttpPost]
        [Route("Create")]
        public IActionResult Insert(StudentDTO student)
        {
            ResponseObject response = new ResponseObject();

            try
            {
                iStudentService.Insert(student);
                response.Data = true;

            }
            catch (Exception ex)
            {
                response.ErrorDescription = ex.Message;
            }

            return Ok(response);
        }


        /// <summary>
        /// Update a student record.
        /// </summary>
        /// <param name="student">Student record</param>
        /// <param name="email">Email of the student</param>
        /// <returns></returns>


        [HttpPut]
        public IActionResult Update(StudentDTO student)
        {
            ResponseObject response = new ResponseObject();

            try
            {
                iStudentService.Update(student, student.Email);
                response.Data = true;

            }
            catch (Exception ex)
            {
                response.ErrorDescription = ex.Message;
            }

            return Ok(response);
        }



        /// <summary>
        /// Delete a student record by given email
        /// </summary>
        /// <param name="email">Email of the student</param>
        /// <returns></returns>

        [HttpDelete]
        [Route("{email}")]
        public IActionResult Delete(string email)
        {
            ResponseObject response = new ResponseObject();

            try
            {
                iStudentService.Delete(email);
                response.Data = true;

            }
            catch (Exception ex)
            {
                response.ErrorDescription = ex.Message;
            }

            return Ok(response);
        }


        /// <summary>
        /// Returns student count for given institute name.Mongo DB aggregation used.
        /// </summary>
        /// <param name="institute">Institute name</param>
        /// <returns></returns>

        [HttpGet]
        [Route("StudentsCountForInstitutes/{institute}")]
        public IActionResult StudentsCountForInstitutes(string institute)
        {
            ResponseObject response = new ResponseObject();

            try
            {
                var result = iStudentService.StudentsCountForInstitutes(institute);
                response.Data = result;

            }
            catch (Exception ex)
            {
                response.ErrorDescription = ex.Message;
            }

            return Ok(response);
        }



    }
}
