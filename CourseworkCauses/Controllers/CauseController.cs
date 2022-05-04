using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseworkCauses.Models;
using CourseworkCauses.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//Controllers handle user requests (implement services) and conduct operations on the data given by the Models,
//and renders views in the broswer.
// these operations are given by the services/interfaces

namespace CourseworkCauses.Controllers
{
    public class CauseController : Controller
    {
        //inject an instance of the services into controller classes (keeps controllers independent)
        private readonly ICauseType _causetypeService;
        private readonly ICause _causeService;
        //built in usermanager to get current users
        private static UserManager<ApplicationUser> _userManager;

        public CauseController(ICause causeService, ICauseType causetypeService, UserManager<ApplicationUser> userManager)
        {
            _causetypeService = causetypeService;
            _userManager = userManager;
            _causeService = causeService;
        }

        //returns view model for cause index to display
        public IActionResult Index(int id)
        {
            var cause = _causeService.GetById(id);
            var signatures = BuildSignatures(cause.Signatures);

            var model = new CauseIndexModel
            {
                Id = cause.Id,
                Title = cause.Title,
                AuthorId = cause.User.Id,
                AuthorEmail = cause.User.UserName,
                TimeCreated = cause.TimeCreated,
                CauseContent = cause.Content,
                Signatures = signatures
            };

            return View(model);
        }

        //returns view model for creating causes
        public IActionResult Create(int id)
        {
            var causetype = _causetypeService.GetByID(id);
            var model = new NewCauseModel
            {
                CauseTypeName = causetype.Title,
                CauseTypeId = causetype.Id,
                AuthorEmail = User.Identity.Name,
            };

            return View(model);
        }

        //Post attribute request to creates new cause when form is posted
        //Entity frameworks sends it to database
        [HttpPost]
        public async Task<IActionResult> AddCause(NewCauseModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var cause = BuildCause(model, user);

            _causeService.Add(cause).Wait();

            return RedirectToAction("Index", "Cause", new { id = cause.Id });
        }

        //build model for new causes
        private Cause BuildCause(NewCauseModel model, ApplicationUser user)
        {
            var causetype = _causetypeService.GetByID(model.CauseTypeId);
            return new Cause
            {
                Title = model.Title,
                Content = model.Content,
                TimeCreated = DateTime.Now,
                User = user,
                CauseType = causetype
            };
        }

        //build new model for collection of signatures that can be mapped against the signature model
        private IEnumerable<SignatureModel> BuildSignatures(IEnumerable<Signature> signatures)
        {
            return signatures.Select(signature => new SignatureModel
            {
                Id = signature.Id,
                Email = signature.User.UserName,
                AuthorId = signature.User.Id,
                Created = signature.TimeCreated,
                SignatureContent = signature.Content
            });
        }
    }
}