using AutoMapper;
using ContactManager.DAL.Repository;
using ContactManager.Models;
using ContactManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(PersonDTO))]
        public async Task<IHttpActionResult> GetOne(int id)
        {
            Person item = _repository.GetOne(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PersonDTO>(item));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost, Route("")]
        [ResponseType(typeof(Person))]
        public IHttpActionResult PostInventory(Person item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _repository.Add(item);
            }
            catch (Exception ex)
            {
                throw;
            }
            return CreatedAtRoute("DisplayRoute", new { id = item.Id }, item);
        }
        [HttpDelete, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
        [HttpPut, Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChange(int id, Person item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != item.Id)
            {
                return BadRequest();
            }
            try
            {
                _repository.Save(item);
            }
            catch (Exception ex)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
