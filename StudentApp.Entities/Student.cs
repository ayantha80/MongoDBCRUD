using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Entities
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        /// <summary>
        /// Primery Key
        /// </summary>
        /// 
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Student Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Student Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///  Student TelephoneNumber
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        ///  Student Institute
        /// </summary>
        public Institute Institute { get; set; }


    }
}
