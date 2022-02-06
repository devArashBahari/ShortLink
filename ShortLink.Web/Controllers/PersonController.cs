using Application.Interfaces;
using Domain.Models.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ShortLink.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IpersonService _Personservice;
        public PersonController(IpersonService Personservice)
        {
            _Personservice = Personservice;
        }
        [HttpGet("GetAll")]
        public async Task<List<Person>> GetAllAsync()
        {
            var Person = await _Personservice.GetAllAsync();
            return Person;
        }
        [HttpGet("GenerateExcel")]
        public async Task<ActionResult> GenerateExcel()
        {
            string FilePathName = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", "TestReport" + DateTime.Now.Ticks.ToString() + ".xls");

            List<Person> Persons = await GetAllAsync();

            string htmlstring = "<table style='width:800px; border:solid;border-width:1px;'> <thead> <tr> ";
            htmlstring += "<th style='width:10%;text-align:left;'>FullName</th>";
            htmlstring += "<th style='width:30%;text-align:left;'>Status</th>";
            htmlstring += "<th style='width:30%;text-align:left;'>IsLegal</th>";
            htmlstring += "<th style='width:30%;text-align:left;'>PersonType</th>";
            htmlstring += "</tr></thead>  <tbody>";

            foreach (Person obj in Persons)
            {
                htmlstring += "<tr><td style = 'width:10%;text-align:left;'> " + obj.FullName + " </td> ";
                htmlstring += "<td style='width:30%;text-align:left;'>" + obj.Status + "</td>";
                htmlstring += "<td style='width:30%;text-align:left;'>" + obj.IsLegal + "</td>";
                htmlstring += "<td style='width:30%;text-align:left;'>" + obj.PersonType + "</td></tr> ";
            }


            htmlstring += "</tbody></table>";

            System.IO.File.AppendAllText(FilePathName, htmlstring);


            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(FilePathName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(FilePathName);
            return File(bytes, contentType, Path.GetFileName(FilePathName));
        }
    }
}
