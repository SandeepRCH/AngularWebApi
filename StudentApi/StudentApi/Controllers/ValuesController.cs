using StudentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentApi.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        SandeepDBEntities _db;
        public ValuesController()
        {
            _db = new SandeepDBEntities();
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _db.studentInfo.Select(x => new Student()
            {
                Address = x.Address,
                email = x.email,
                FullName = x.FullName,
                Id = x.Id,
                branch = x.Branch
            }).ToList();
        }
        [HttpGet]
        public IEnumerable<Student> GetStudent(int Id)
        {
            return _db.studentInfo.Where(x => x.Id == Id).Select(y => new Student()
            {
                Id = y.Id,
                Address = y.Address,
                email = y.email,
                FullName = y.FullName,
                branch = y.Branch
            });
        }
        [HttpGet]
        public IEnumerable<EducationDetails> GetEducationDetails()
        {
            return _db.EducationalInfo.Select(x => new EducationDetails()
            {
                backlogs = x.backlogs,
                Id = x.Id,
                percentage = x.percentage,
                YOS = x.YOS,
                College = x.College,
                Specialization = x.Specialization
            }).ToList();
        }
        [HttpGet]
        public EducationDetails GetEducationDetails(int ID)
        {
            EducationalInfo E = _db.EducationalInfo.First(x => x.Id == ID);
            EducationDetails ED = new EducationDetails
            {
                Id = E.Id,
                percentage = E.percentage,
                College = E.College,
                backlogs = E.backlogs,
                Specialization = E.Specialization,
                YOS = E.YOS
            };
            return ED;
        }
        [HttpGet]
        public IEnumerable<BackLogs> GetBackLogs()
        {
            return _db.BackLogInfo.Select(x => new BackLogs()
            {
                Id = x.Id,
                current_status = x.current_status,
                subject = x.subject
            }).ToList();
        }
        [HttpGet]
        public IEnumerable<BackLogs> GetBackLogs(int ID)
        {
            return _db.BackLogInfo.Where(x => x.Id == ID).Select(y => new BackLogs()
            {
                Id = y.Id,
                current_status = y.current_status,
                subject = y.subject
            }).ToList();
        }
        [HttpPost]
        public string AddStudent([FromBody]studentInfo student)
        {
            try
            {
                _db.studentInfo.Add(student);
                _db.SaveChanges();
                return "Record Added Successfully";
            }
            catch (Exception e)
            {
                if(e.HResult == -2146233087)
                {
                    return "Id Number Already Exists";
                }
                else if (e.HResult == -2146232032)
                {
                    return "Data incorrect";
                }
                return e.InnerException.InnerException.Message;
            }

        }
        [HttpPut]
        public string PutStudent(int Id, studentInfo student)
        {
            try
            {
                studentInfo eStudent = _db.studentInfo.First(x => x.Id == Id);
                eStudent.Id = Id;
                eStudent.FullName = student.FullName;
                eStudent.Address = student.Address;
                eStudent.email = student.email;
                eStudent.Branch = student.Branch;
                _db.SaveChanges();
                return "Updated Successfully";
            }
            catch (Exception e)
            {
                return "Error Updating";
            }

        }
        [HttpPut]
        public string PutEducation(int Id,EducationalInfo Edu)
        {
            try
            {
                EducationalInfo E = _db.EducationalInfo.First(x => x.Id == Edu.Id);
                E.Id = Edu.Id;
                E.backlogs = Edu.backlogs;
                E.College = Edu.College;
                E.percentage = Edu.percentage;
                E.Specialization = Edu.Specialization;
                E.YOS = Edu.YOS;
                _db.SaveChanges();
                return "Updated Successfully";
            }
            catch(Exception e)
            {
                return "Error updating";
            }
        }
    }
}
