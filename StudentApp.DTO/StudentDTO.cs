using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.DTO
{
    public class StudentDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
       // public List<CourseDTO> CoursesFollowed { get; set; }

        public InstituteDTO Institute { get; set; }
    }
}
