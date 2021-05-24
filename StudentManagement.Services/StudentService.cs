using AutoMapper;
using StudentApp.DTO;
using StudentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository iStudentRepository = null;

        public StudentService(IStudentRepository _iStudentRepository)
        {
            iStudentRepository = _iStudentRepository;
        }


        /// <summary>
        /// Student create.
        /// </summary>
        /// <param name="student">Student information record</param>
        public void Insert(StudentDTO studentDTO)
        {
            try
            {
                // Auto Mapper configuration.
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StudentDTO, StudentApp.Entities.Student>();
                    cfg.CreateMap<InstituteDTO, StudentApp.Entities.Institute>();
                });

                IMapper iMapper = config.CreateMapper();

                // Mapping DTO objects to Entities.
                var updatedDTO = iMapper.Map<StudentDTO, StudentApp.Entities.Student>(studentDTO);

                //Student record create.
                iStudentRepository.Insert(updatedDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Return student information by email
        /// </summary>
        /// <param name="email">Student email</param>
        /// <returns></returns>
        public StudentDTO Select(string email)
        {
            // Get the result.
            var result = iStudentRepository.Select(email);
            // Auto Mapper configuration.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentApp.Entities.Student, StudentDTO>();
                cfg.CreateMap<StudentApp.Entities.Institute, InstituteDTO>();
            });

            // Mapping Entities objects to DTOs.
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<StudentApp.Entities.Student, StudentDTO>(result);

            return destination;
        }


        /// <summary>
        /// Delete a student record by given email
        /// </summary>
        /// <param name="email">Email of the student</param>
        /// <returns></returns>
        public void Delete(string email)
        {
            iStudentRepository.Delete(email);
        }



        /// <summary>
        /// Update a student record.
        /// </summary>
        /// <param name="student">Student record</param>
        /// <param name="email">Email of the student</param>
        /// <returns></returns>
        public void Update(StudentDTO student, string email)
        {
            // Auto Mapper configuration.
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, StudentApp.Entities.Student>();
                cfg.CreateMap<InstituteDTO, StudentApp.Entities.Institute>();
            });

            // Mapping DTO objects to Entities.
            IMapper iMapper = config.CreateMapper();

            var updatedDTO = iMapper.Map<StudentDTO, StudentApp.Entities.Student>(student);
            //Update student record.
            iStudentRepository.Update(updatedDTO, email);
        }

        /// <summary>
        /// Returns student count for given institute name.
        /// </summary>
        /// <param name="institute">Institute name</param>
        /// <returns></returns>
        public int StudentsCountForInstitutes(string institute)
        {
            return iStudentRepository.StudentCountForInstitutes(institute);

        }
    }
}
