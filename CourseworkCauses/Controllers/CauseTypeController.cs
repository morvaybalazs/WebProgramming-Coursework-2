using CourseworkCauses.Models;
using CourseworkCauses.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

//Controllers handle user requests and conduct operations on the data given by the Models,
//and renders views in the broswer.
// these operations are given by the services/interfaces
namespace CourseworkCauses.Controllers
{
    public class CauseTypeController : Controller
    {
        //inject an instance of the services (keeps controllers somewhat independent)
        private readonly ICauseType _causetypeService;
        private readonly ICause _causeService;

        public CauseTypeController(ICauseType causetypeService, ICause causeService)
        {
            _causetypeService = causetypeService;
            _causeService = causeService;
        }

        //returns view model for cause types index page
        public IActionResult Index()
        {
            var causetypes = _causetypeService.GetAll().Select(causetype => new CauseTypeListingModel
            {
                Id = causetype.Id,
                Name = causetype.Title,
                Description = causetype.Description,
            });

            var model = new CauseTypeIndexModel
            {
                CauseTypeList = causetypes
            };
            return View(model);
        }

        //returns view model for posted causes 
        public IActionResult CauseTopic(int id)
        {
            var causetype = _causetypeService.GetByID(id);
            var causes = causetype.Causes;
            var causeListings = causes.Select(cause => new CauseListingModel
            {
                Id = cause.Id,
                AuthorId = cause.User.Id,
                AuthorEmail = cause.User.Email,
                Title = cause.Title,
                TimeCreated = cause.TimeCreated.ToString(),
                SignaturesCount = cause.Signatures.Count(),
                CauseTypeListingModel = BuildCauseTypeListing(cause)
            });

            //returns view model for Cause Topics 
            var model = new CauseTypeTopicModel
            {
                Causes = causeListings,
                CauseType = BuildCauseTypeListing(causetype)
            };

            return View(model);
        }
        
        //returns view model for creating causes 
        public IActionResult Create()
        {
            var model = new AddCauseTypeModel();
            return View(model);
        }
        
        //Post request creates new cause type (only available for admin)
        [HttpPost]
        public async Task<IActionResult> AddCauseType(AddCauseTypeModel model)
        {
            var causetype = new CauseType
            {
                Title = model.Title,
                Description = model.Description,
                TimeCreated = DateTime.Now
            };
            await _causetypeService.Create(causetype);
            return RedirectToAction("Index", "CauseType");
        }

        //Build private method for causetype listings for particular causes
        //takes an instance of a cause and builds the listing model from it
        private CauseTypeListingModel BuildCauseTypeListing(Cause cause)
        {
            var causetype = cause.CauseType;
            return BuildCauseTypeListing(causetype);
        }

        private CauseTypeListingModel BuildCauseTypeListing(CauseType causetype)
        {
            return new CauseTypeListingModel
            {
                Id = causetype.Id,
                Name = causetype.Title,
                Description = causetype.Description,

            };
        }
    }
}