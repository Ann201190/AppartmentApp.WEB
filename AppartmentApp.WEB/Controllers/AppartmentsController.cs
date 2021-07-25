using AppartmentApp.Business.Services;
using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.VewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public GetAppartmentIdViewModel Get(int Id)
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
