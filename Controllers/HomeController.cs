using CSIConference.Data;
using Microsoft.AspNetCore.Mvc;

namespace CSIConference.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;

        public HomeController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
