using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_Server.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class HomeController : Controller
    {
        public IWebHostEnvironment hostingEnvironment;
        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        [Route("Download")]
        public FileStreamResult Download()
        {
            string fullPath = this.hostingEnvironment.ContentRootPath + "\\wwwroot\\2.png";
            FileStream fileStreamInput = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            FileStreamResult fileStreamResult = new FileStreamResult(fileStreamInput, "APPLICATION/octet-stream");
            fileStreamResult.FileDownloadName = "Custom.png";
            return fileStreamResult;
        }
    }
}
