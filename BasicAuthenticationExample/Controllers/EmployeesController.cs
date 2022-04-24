using BasicAuthenticationExample.BasicAuth;
using BasicAuthenticationExample.Data;
using BasicAuthenticationExample.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthenticationExample.Controllers
{
    [Authentication]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> repository;
        public EmployeesController(IRepository<Employee> _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public ActionResult GetEmployeeList()
        {
            var employees = repository.GetAll();
            return Ok(employees);

        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetEmployeeById(int id)
        {
            var employees = repository.GetById(id);
            return Ok(employees);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody] Employee employee)
        {
            repository.Add(employee);
            repository.SaveAll();
            return Ok(employee);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Employee employee)
        {
            repository.Update(employee);
            repository.SaveAll();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.SaveAll();
            return Ok();
        }
    }
}
