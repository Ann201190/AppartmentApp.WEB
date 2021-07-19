using AppartmentApp.Business.Services;
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
            _appartmentService = new AppartmentsService( new AppartmentsRepository());
        }

        [HttpGet]
        public IEnumerable<GetAppartmentModel> Get()
        {
            return _appartmentService.Get();
        }
    }
}
