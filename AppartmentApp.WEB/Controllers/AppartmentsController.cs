using AppartmentApp.Business.Services;
using AppartmentApp.DataAccess.Entities;
using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.VewModels.Appartments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AppartmentApp.WEB.Controllers
{
    [Route("api/[controller]")]
    public class AppartmentsController : Controller
    {
        public readonly AppartmentsService _appartmentService;
        public AppartmentsController()
        {
            _appartmentService = new AppartmentsService(new AppartmentsRepository());
        }

        [HttpGet]
        public IEnumerable<GetAppartmentViewModel> Get()
        {
            return _appartmentService.Get();
        }

        [HttpGet("{Id}")]
        public GetAppartmentViewModel Get(int Id)
        {
            return _appartmentService.Get(Id);
        }


        [HttpPost]
        public bool Post([FromBody] PostAppartmentViewModel postAppartmentModel)
        {
            PostAppartmentViewModel postAppartmentModel1 =  postAppartmentModel;

          return _appartmentService.Post(postAppartmentModel);
        }
    }
}
