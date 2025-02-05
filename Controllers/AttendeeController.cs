using System.ComponentModel.DataAnnotations;
using CSIConference.Data;
using CSIConference.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CSIConference.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;

        public AttendeeController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }
        [HttpGet]
        public IActionResult CheckRegistration(Attendee _attendee)
        {
            PopulateStatusDLL(_attendee.CapacityId);
            return View();
        }
        [HttpPost]
        public IActionResult CheckRegistration([Required] string email)
        {
            if (ModelState.IsValid)
            {
                var _attendee = _conferenceRepository.GetAttendeeByEmail(email);
                if (_attendee == null)
                {
                    return RedirectToAction("Register", _attendee);
                }
                else
                {
                    ViewBag.ErrorMessage = "You are already registered for the conference!";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register(Attendee attendee)
        {
            PopulateStatusDLL(attendee.CapacityId);
            return View(attendee);
        }
        [HttpPost, ActionName("Register")]
        public IActionResult RegisterUpdate(Attendee attendee)
        {
            if (attendee.CapacityId != 1 && ModelState.IsValid)
            {
                try
                {
                    _conferenceRepository.UpdateAttendee(attendee);
                    _conferenceRepository.SaveChanges();
                    return RedirectToAction("Confirmation", attendee);
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                    PopulateStatusDLL(attendee.CapacityId);
                    return View(attendee);
                }
            }
            else
            {
                if (attendee.CapacityId == 1)
                
                    PopulateStatusDLL(attendee.CapacityId);
                    return View(attendee);
            }
        }

        public IActionResult Confirmation()
        {
            return View();
        }
        private void PopulateStatusDLL(object obj = null)
        {
            ViewBag.Capacities = new SelectList(_conferenceRepository.GetAllCapacities().OrderBy(c => c.CapacityName), "CapacityId", "CapacityName", obj);
        }
        public IActionResult AttendeeList()
        {
            var conference = _conferenceRepository.GetAllAttendees().OrderBy(c => c.Name).ToList();
            return View(conference);
        }
    }
}
