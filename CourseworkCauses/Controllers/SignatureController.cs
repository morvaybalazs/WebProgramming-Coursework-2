using System;
using System.Threading.Tasks;
using CourseworkCauses.Models;
using CourseworkCauses.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

//Controllers handle user requests and conduct operations on the data given by the Models,
//and renders views in the broswer.
//these operations are given by the services/interfaces

namespace LambdaForum.Controllers
{
    public class SignatureController : Controller
    {
        //Inject an instance of the services (keeps controllers somewhat independent)
        //built in usermanager to get current users
        private readonly ICauseType _causetypeService;
        private readonly ICause _causeService;
        private readonly ApplicationUser _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SignatureController(ICauseType causetypeService,
            ICause causeService,
            ApplicationUser userService,
            UserManager<ApplicationUser> userManager)
        {
            _causetypeService = causetypeService;
            _causeService = causeService;
            _userService = userService;
            _userManager = userManager;
        }

        // Returns view model of creating a signature
        public async Task<IActionResult> Create(int id)
        {
            var cause = _causeService.GetById(id);
            var causetype = _causetypeService.GetByID(cause.CauseType.Id);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var model = new SignatureModel
            {
                CauseContent = cause.Content,
                CauseTitle = cause.Title,
                CauseId = cause.Id,

                CauseTypeId = causetype.Id,
                CauseTypeName = causetype.Title,

                AuthorId = user.Id,
                Email = user.UserName,

                Created = DateTime.Now
            };

            return View(model);
        }

        //Post request creates new signature when form is posted
        //Entity frameworks sends it to database
        [HttpPost]
        public async Task<IActionResult> AddSignature(SignatureModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var signature = BuildSignature(model, user);
            await _causeService.AddSignature(signature);

            return RedirectToAction("Index", "Cause", new { id = model.CauseId });
        }

        //Build model for new signatures
        private Signature BuildSignature(SignatureModel model, ApplicationUser user)
        {
            var now = DateTime.Now;
            var cause = _causeService.GetById(model.CauseId);

            return new Signature
            {
                Id = model.Id,
                Cause = cause,
                Content = model.SignatureContent,
                TimeCreated = now,
                User = user
            };
        }
    }
}