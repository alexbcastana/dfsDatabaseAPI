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
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Salary>0));
            return View(players);
        }
        [ActionName("DeselectAll")]
        public async Task<ActionResult> DeselectAllAsync()
        {
            if (ModelState.IsValid)
            {
                var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.InLineup == true));
                foreach (var player in players)
                {
                    player.InLineup = false;
                    await DocumentDBRepository<Player>.UpdatePlayerAsync(player.Id, player);
                }
                players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Salary > 0));
            }
            return RedirectToAction("Index");
        }
        [ActionName("DeselectPlayer")]
        public async Task<ActionResult> DeselectPlayerAsync(String id)
        {
            if (ModelState.IsValid)
            {
                var player = await DocumentDBRepository<Player>.GetPlayerAsync(id);
                player.InLineup = false;
                await DocumentDBRepository<Player>.UpdatePlayerAsync(player.Id, player);
            }
            return RedirectToAction("Index");
        }
        [ActionName("SelectPlayer")]
        public async Task<ActionResult> SelectPlayerAsync(String id)
        {

            if (ModelState.IsValid)
            {
                var player = await DocumentDBRepository<Player>.GetPlayerAsync(id);
                player.InLineup = true;
                await DocumentDBRepository<Player>.UpdatePlayerAsync(player.Id, player);
            }
            return RedirectToAction("Index");
        }
        [ActionName("All")]
        public async Task<ActionResult> AllAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Salary>0));
            return View("~/Views/MainPage/Index.cshtml", players);
        }
        [ActionName("PG")]
        public async Task<ActionResult> PGAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "PG" || d.InLineup == true));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("SG")]
        public async Task<ActionResult> SGAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "SG" || d.InLineup == true));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("C")]
        public async Task<ActionResult> CAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "C" || d.InLineup == true));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("PF")]
        public async Task<ActionResult> PFAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "PF" || d.InLineup == true));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("SF")]
        public async Task<ActionResult> SFAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Position == "SF" || d.InLineup == true));
            return View("~/Views/MainPage/Index.cshtml", players);
        }

        [ActionName("Validate")]
        public async Task<ActionResult> ValidateAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.InLineup));
            int budget = 60000;
            foreach (Player player in players)
            {
                budget = budget - player.Salary;
            }
            return View(budget > 0);
        }
    }
}