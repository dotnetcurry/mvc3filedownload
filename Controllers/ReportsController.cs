using System;
using System.Linq;
using System.Web.Mvc;
using MVC3_Returning_Files.Models;

namespace MVC3_Returning_Files.Controllers
{
    public class ReportsController : Controller
    {
        DataClasses objData;

        public ReportsController()
        {
            objData = new DataClasses(); 
        }

        //
        // GET: /Reports/

        public ActionResult Index()
        {
            var files = objData.GetFiles();  
            return View(files);
        }

       
        public FileResult Download(string id)
        {
            int fid = Convert.ToInt32(id);
            var files = objData.GetFiles();
            string filename = (from f in files
                               where f.FileId == fid
                               select f.FilePath).First();
            string contentType = "application/pdf";
            //Parameters to file are
            //1. The File Path on the File Server
            //2. The connent type MIME type
            //3. The paraneter for the file save asked by the browser
            return File(filename, contentType,"Report.pdf");
        }

    }
}
