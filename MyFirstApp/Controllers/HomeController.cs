using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult getEmpName(int empId)
        {
            var employees = new[]
            {
                new {empId=1,empName="scots", empSalery=8000 },
                new {empId=2,empName="kevin", empSalery=2500},
                new {empId=3,empName="raja", empSalery=3500}
             };
            string matchingEmpName=null;
            foreach(var emp in employees)
            {
                if(emp.empId== empId)
                {
                    matchingEmpName = emp.empName;
                }
            }
            // return new ContentResult() {Content=matchingEmpName,ContentType="text/plain" };// returns the object of content result class
            //insted of above lengthy process we can use shorcut by calling content only
            return Content(matchingEmpName,"text/plain");
        }

        public ActionResult getPaySlip(int empID)
        {
            string fileName = "~/paySlip" + empID + ".pdf";
            return File(fileName, "application/pdf");
        }
        public ActionResult getEmpFacebookPage(int empID)
        {
            string fbUrl= "http://www.facebook.com/emp" + empID;
            return Redirect(fbUrl);

        }
        public ActionResult studentDetails()
        {
            ViewBag.studentId = 101;
            ViewBag.studentName = "Scott";
            ViewBag.marks = 80;
            ViewBag.noOfSem = 6;
            ViewBag.subjects=new List<string>() {"maths","physics","chemistry" };
            return View();
        }
        public ActionResult RequestExample()
        {
            ViewBag.url=Request.Url;
            ViewBag.physicalRequestPath = Request.PhysicalApplicationPath;
            ViewBag.path = Request.Path;
            ViewBag.browserType = Request.Browser.Type;
            ViewBag.queryString = Request.QueryString["n"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.methods = Request.HttpMethod;

            return View();
        }
        public ActionResult ResponseExample()
        {
            Response.Write("response is generated");
            Response.ContentType = "text/plain";
            Response.Headers["Server"] = "My Server";
            return View();
        }
    }
}