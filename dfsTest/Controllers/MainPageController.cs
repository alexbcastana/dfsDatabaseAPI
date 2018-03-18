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
        public async Task<ActionResult> Index()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "C"));
            return View(players);
        }
        [ActionName("SelectPlayer")]
        public async Task<ActionResult> SelectPlayerAction(Player player)
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == player.Position));
            return View("~/Views/MainPage/Index.cshtml", player);
        }
        [ActionName("PG")]
        public async Task<ActionResult> PGAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "PG"));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("SG")]
        public async Task<ActionResult> SGAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "SG"));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("C")]
        public async Task<ActionResult> CAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "C"));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("PF")]
        public async Task<ActionResult> PFAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "PF"));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("SF")]
        public async Task<ActionResult> SFAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "SF"));
            return View("~/Views/MainPage/Index.cshtml", players);
        }
    }
}