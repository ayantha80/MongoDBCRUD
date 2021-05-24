using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Entities
{
    [BsonIgnoreExtraElements]
    public class Institute
    {
        /// <summary>
        /// Primery Key
        /// </summary>
        ObjectId Id { get; set; }

        /// <summary>
        /// Institute Name
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// Institute Country

        /// </summary>
        /// 
        public string Country { get; set; }

        /// <summary>
        /// Institute EntryFee
        /// </summary>        /// 
        public decimal EntryFee { get; set; }
    }
}
