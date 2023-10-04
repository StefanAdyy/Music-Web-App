using BusinessLogic.Abstract;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompositionRoot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityBL _nationalityBL;

        public NationalityController(INationalityBL nationalityBL)
        {
            _nationalityBL = nationalityBL;
        }

        [HttpGet]
        public List<Nationality> Get()
        {
            return _nationalityBL.Read();
        }

        [HttpGet]
        [Route("GetById")]
        public Nationality Get(int nationalityId)
        {
            return _nationalityBL.Read(nationalityId);
        }

        [HttpPost]
        public void Post(Nationality nationality)
        {
            _nationalityBL.Create(nationality);
        }

        [HttpPut]
        public void Update(Nationality nationalityId)
        {
            _nationalityBL.Update(nationalityId);
        }

        [HttpDelete]
        public void Delete(int nationalityId)
        {
            _nationalityBL.Delete(nationalityId);
        }
    }
}