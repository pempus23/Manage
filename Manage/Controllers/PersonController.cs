using ContactManager.DAL.Repository;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Manage.Controllers
{
    [RoutePrefix("api/Manage")]
    public class PersonController : ApiController
    {
        private readonly IRepository<Person> _repository;
        public PersonController()
        {

        }
        public PersonController(IRepository<Person> repository)
        {
            _repository = repository;
        }
        [HttpGet, Route("")]
        public IHttpActionResult GetList()
        {
            return Ok(_repository.GetAll());
        }
    }
}
