using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class RegisterStudentManager
    {
        private RegisterStudentGateway _registerStudentGateway = new RegisterStudentGateway();
        private DepartmentGateway _departmentGateway = new DepartmentGateway();
        
        public string SaveRegisterStuden(RegisterStudentModel registerStudentModel)
        {
            Registernumber(registerStudentModel);
            if (_registerStudentGateway.InsertRegisterStudent(registerStudentModel) > 0)
            {
                return "Save Successfull"; 
            }
            else
            {
                return "Save Fail"; 
            }
        }

        public RegisterStudentModel Registernumber(RegisterStudentModel registerStudent)
        {
            string departmentCode = _departmentGateway.GateDepartmentCodeByDepartmentId(registerStudent.DepartmentId);  
            List<RegisterStudentModel> student =
                _registerStudentGateway.GateStudentByDepartmentId(registerStudent.DepartmentId);
            string year = registerStudent.Date.ToString("yyyy");
            int yearcount = 0; 
            int count = student.Count;
            if (count !=0)
            {
            foreach (var studentList in student)
                {
                    string regYear = studentList.Date.ToString("yyyy"); 
                    if (regYear == year)
                    {
                        yearcount++; 
                    }
                }
               }
            yearcount++;
            registerStudent.RegistationNumber = departmentCode + "-" + year + "-" + yearcount.ToString().PadLeft(3, '0');
            return registerStudent;
        }


        public List<RegisterStudentModel> GateRegistationNumberManager()
        {
            return _registerStudentGateway.GateRegistationNumberGateway(); 
        } 
    }
}