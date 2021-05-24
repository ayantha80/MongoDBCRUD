using MongoDB.Bson;
using StudentApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Repositories
{
    public interface IStudentRepository
    {
       void Insert(Student student);
       List<Student> List();
       Student Select(string email);
       void Delete(string email);
       int StudentCountForInstitutes(string InstituteName);
       void Update(Student student, string email);

    }
}
