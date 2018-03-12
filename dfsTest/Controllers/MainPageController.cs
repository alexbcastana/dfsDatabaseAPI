using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using dfsTest.Models;

namespace dfsTest.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("PG")]
        public async Task<ActionResult> PGAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "PG"));
            return View(players);
        }

        [ActionName("SG")]
        public async Task<ActionResult> SGAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "SG"));
            return View(players);
        }

        [ActionName("C")]
        public async Task<ActionResult> CAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "C"));
            return View(players);
        }

        [ActionName("PF")]
        public async Task<ActionResult> PFAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "PF"));
            return View(players);
        }

        [ActionName("SF")]
        public async Task<ActionResult> SFAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "SF"));
            return View(players);
        }
    }
}