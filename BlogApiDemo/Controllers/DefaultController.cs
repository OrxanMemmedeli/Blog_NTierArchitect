using BlogApiDemo.DLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        private readonly Context _context = new Context();



        [HttpGet]
        public ActionResult GetList()
        {
            var list = _context.Employees.ToList();
            return Ok(list);
        }

    }
}
