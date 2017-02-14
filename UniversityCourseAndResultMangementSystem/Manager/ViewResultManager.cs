using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UniversityCourseAndResultMangementSystem.Gateway;
using UniversityCourseAndResultMangementSystem.Models;

namespace UniversityCourseAndResultMangementSystem.Manager
{
    public class ViewResultManager
    {
        ViewResultGateway viewResultGateway = new ViewResultGateway();

        public List<ViewResultModel> GateListOfStudentResult(int StudentId)
        {
            return viewResultGateway.GateListOfStudentResult(StudentId);
        }


        public ViewResultModel GetIdByStudentInfo(int id)
        {
            return viewResultGateway.GetIdByStudentInfo(id); 
        }
    }
}