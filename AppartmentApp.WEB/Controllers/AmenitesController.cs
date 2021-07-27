using AppartmentApp.Business.Services;
using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.VewModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppartmentApp.WEB.Controllers
{
    [Route("api/[controller]")]
    public class AmenitesController : ControllerBase
    {
        public readonly AmanitesService _amanitesService ;
        public AmenitesController()
        {
            _amanitesService = new AmanitesService(new AmenitiesRepository());
        }

        [HttpGet]
        public IEnumerable<GetAmenityViewModel> Get()
        {
            return _amanitesService.Get();
        }

        [HttpGet("{Id}")]
        public IEnumerable<GetAdressByAmenityViewModel> Get(int Id)
        {
            return _amanitesService.Get(Id);
        }

        [HttpPost]
        public bool Post([FromBody] PostAmenityViewModel postAmenityViewModel)
        {
            return _amanitesService.Post(postAmenityViewModel);
        }

        [HttpPut]
        public bool Put([FromBody] PutAmenityViewModel putAmenityViewModel)
        {
            return _amanitesService.Put(putAmenityViewModel);
        }

        [HttpDelete("{Id}")]
        public bool Delete (int id)
        {
            return _amanitesService.Delete(id);
        }
    }
}
