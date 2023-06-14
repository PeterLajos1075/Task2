using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;
using Task2.Context;
using Task2.Models;
using Task2.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICrud<AddressModel> _addressRepository;

        public TestController(ICrud<AddressModel> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<AddressModel> Read()
        {
            var data = _addressRepository.Read();
            return data;
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, AddressModel model)
        {
            if(id > 0)
            {
                _addressRepository.Update(id, model);
                return Ok();
            }
            return BadRequest();
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public ActionResult ReadById(int id)
        {
            var Address = _addressRepository.ReadById(id);

            if (Address == null) 
            {
                return NotFound();
            }
            return Ok(Address);
        }

        //POST api/<TestController>
        [HttpPost]
        public ActionResult Create(AddressModel addressModel) 
        {
            _addressRepository.Create(addressModel);
            return NoContent();
        }

        #region Old CodeBase
        //POST api/<TestController>
        //[HttpPost]
        //[Route("AddTestData")]
        //public ActionResult AddTestData()
        //{
        //    _addressRepository.AddTestData();
        //    return NoContent();
        //}
        #endregion

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _addressRepository.Delete(id);
            return NoContent();
        }
    }
}
