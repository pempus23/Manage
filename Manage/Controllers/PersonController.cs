using AutoMapper;
using ContactManager.DAL.Repository;
using ContactManager.Models;
using ContactManager.Models.DTO;
using System.Collections.Generic;
using System.Web.Http;

namespace Manage.Controllers
{
    [RoutePrefix("api/Manage")]
    public class PersonController : ApiController
    {
        private readonly IRepository<Person> _repository;
        private readonly IMapper _mapper;
        public PersonController()
        {

        }
        public PersonController(IRepository<Person> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet, Route("")]
        public IHttpActionResult GetList()
        {
            var people = _repository.GetAll();
            return Ok(_mapper.Map<List<PersonDTO>>(people));

        }
    }
}
