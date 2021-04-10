using HDot_Vew.Interface;
using HDot_Vew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HDot_Vew.Controllers
{
    //[Route("[api/[details]]")]
   [Route("api/[controller]")]

    public class DetailsController : Controller
    {
        
        private readonly IConfiguration _configuration;
        private readonly IDetails detailsrepository;

        public DetailsController( IDetails detailsrepository)
        {
           
            this.detailsrepository = detailsrepository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost("AddDetails")]
        public ActionResult AddDetails([FromBody] DetailsModel details)
        {
            var va=detailsrepository.insertdata(details);
            return new JsonResult(va);

            //return "abhi";
        }
        [HttpGet("GetAllDetails")]
        public ActionResult GetAllDetails()
        {
            var x = detailsrepository.GetDetails();
            IEnumerable<DetailsModel> model = detailsrepository.GetDetails().Select(s => new DetailsModel
                    {
                Name = s.Name,
                Age = s.Age
            });
            return new JsonResult(model);
            //return Ok();
        }
        [HttpPost("DeleteDetails")]
        public ActionResult DeleteDetails([FromBody] DetailsModel details)
        {
            var de = detailsrepository.deletedata(details);
            return new JsonResult(de);

        }
        [HttpPost("EditDetails")]
        public ActionResult EditDetails([FromBody] DetailsModel details)
        {
            var de = detailsrepository.editdata(details);
            return new JsonResult(de);
        }
        //[HttpPost("Login")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login([FromBody] LoginModel applicationUser)
        //{
        //    //JwtRepository jwt = new JwtRepository(_jwtOptions, _configuration);
        //    //JwtAccessToken token = await jwt.VaidateLogin(applicationUser);
        //    //my
        //    var de = detailsrepository.login(applicationUser);
        //    return new JsonResult(de);
        //}
        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginModel applicationUser)
        {
            var de = detailsrepository.login(applicationUser);
            return new JsonResult(de);
        }

    }
}
