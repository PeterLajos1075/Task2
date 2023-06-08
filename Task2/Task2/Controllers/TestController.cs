using Microsoft.AspNetCore.Mvc;
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
        private readonly AddressRepository _addressRepository;


        public TestController(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<AddressModel> Get()
        {
            var data = _addressRepository.GetAll();
            return data;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var Address = _addressRepository.GetById(id);

            if (Address == null) 
            {
                return NotFound();
            }
            return Ok(Address);
        }

        //POST api/<TestController>
        [HttpPost]
        public ActionResult Post(AddressModel addressModel) 
        {
            _addressRepository.Add(addressModel);
            return NoContent();
        }
         
            
        
    }
}
