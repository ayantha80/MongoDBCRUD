using StudentApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace StudentManagement.Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        private IMongoClient client = null;
        public StudentRepository(IMongoClient _client) : base(_client)
        {
            client = _client;
           
            // creating email index.
            var field = new StringFieldDefinition<Student>("Email");
            var indexDefinition = new IndexKeysDefinitionBuilder<Student>().Ascending(field);
            var indexModel = new CreateIndexModel<Student>(indexDefinition);
            base.GetCollection<Student>("student-information").Indexes.CreateOne(indexModel);
        }


        public void Delete(string email)
        {
            var student = Select(email);
            var deleteFilter = Builders<Student>.Filter.Eq("Email", email);
            base.Delete<Student>("student-information", deleteFilter);
        }


        /// <summary>
        /// Student create.
        /// </summary>
        /// <param name="student">Student information record</param>
        public void Insert(Student student)
        {
            //users transactions.
            using (var session = client.StartSession())
            {
                try
                {
                    session.StartTransaction();

                    Expression<Func<Institute, bool>> whereClause = a => a.Name == student.Institute.Name;

                    //If Institute is not exits,record will be inserted
                    if (base.Single<Institute>(whereClause, "Institute") == null)
                    {
                        base.Add<Institute>(student.Institute, "Institute");
                    }

                    //Student record insert.
                    base.Add<Student>(student, "student-information");

                    session.CommitTransaction();
                }
                catch (Exception)
                {
                    session.AbortTransaction();
                    throw;
                }

            }
        }

        /// <summary>
        /// Update a student record.
        /// </summary>
        /// <param name="student">Student record</param>
        /// <param name="email">Email of the student</param>
        /// <returns></returns>
        public void Update(Student student, string email)
        {
            Expression<Func<Student, bool>> whereClause = a => a.Email == email;
            base.Update<Student>(whereClause, student, "student-information");
        }


        /// <summary>
        /// Student List
        /// </summary>
        /// <returns></returns>
        public List<Student> List()
        {
            return base.All<Student>("student-information").ToList();
        }


        /// <summary>
        /// Returns student count for given institute name.
        /// </summary>
        /// <param name="InstituteName">Institute name</param>
        /// <returns></returns>
        public int StudentCountForInstitutes(string InstituteName)
        {
            var collection = base.GetCollection<Student>("student-information");
            // Get the count of students in an Institute
            var result = collection.Aggregate<Student>()
                    .Group(
                            doc => doc.Institute.Name,
                            group => new
                            {
                                InstituteName = group.Key,
                                Total = group.Count()
                            }
                    ).ToList().FirstOrDefault(x => x.InstituteName == InstituteName);

            return result.Total;
        }


        /// <summary>
        /// Return student information by email
        /// </summary>
        /// <param name="email">Student email</param>
        /// <returns></returns>
        public Student Select(string email)
        {
            Expression<Func<Student, bool>> whereClause = a => a.Email == email;
            return base.Single<Student>(whereClause, "student-information");
        }
    }
}
