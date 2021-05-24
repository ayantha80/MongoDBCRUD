using StudentApp.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Services
{
    public interface IStudentService
    {
        /// <summary>
        /// Student create.
        /// </summary>
        /// <param name="student">Student information record</param>
        void Insert(StudentDTO student);

        /// <summary>
        /// Return student information by email
        /// </summary>
        /// <param name="email">Student email</param>
        /// <returns></returns>
        StudentDTO Select(string email);

        /// <summary>
        /// Returns student count for given institute name.
        /// </summary>
        /// <param name="institute">Institute name</param>
        /// <returns></returns>
        int StudentsCountForInstitutes(string institute);

        /// <summary>
        /// Delete a student record by given email
        /// </summary>
        /// <param name="email">Email of the student</param>
        /// <returns></returns>
        void Delete(string email);

        /// <summary>
        /// Update a student record.
        /// </summary>
        /// <param name="student">Student record</param>
        /// <param name="email">Email of the student</param>
        /// <returns></returns>
        void Update(StudentDTO student, string email);
    }
}
