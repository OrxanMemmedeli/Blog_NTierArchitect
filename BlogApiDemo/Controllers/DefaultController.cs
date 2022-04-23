using BlogApiDemo.DLL;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin, Manager, User")]
    public class DefaultController : ControllerBase
    {

        private readonly Context _context = new Context();

        [HttpGet]
        public ActionResult GetList()
        {
            var list = _context.Employees.ToList();
            return Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult CreateEmployee(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Remove(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult PutEmployee(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }
            _context.Update(employee);
            _context.SaveChanges();
            return Ok();
        }
    }
}
