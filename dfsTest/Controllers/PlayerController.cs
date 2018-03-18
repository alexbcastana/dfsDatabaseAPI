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
    public class PlayerController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.Salary > 0 ));
            return View(players);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,FName,LName,Salary,Position")] Player player)
        {
            player.InLineup = false;
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Player>.CreatePlayerAsync(player);
                return RedirectToAction("Index");
            }

            return View(player);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,FName,LName,Salary,Position,InLineup")] Player player)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Player>.UpdatePlayerAsync(player.Id, player);
                return RedirectToAction("Index");
            }

            return View(player);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = await DocumentDBRepository<Player>.GetPlayerAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Player player = await DocumentDBRepository<Player>.GetPlayerAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            return View(player);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id")] string id)
        {
            await DocumentDBRepository<Player>.DeletePlayerAsync(id);
            return RedirectToAction("Index");
        }

    }

}