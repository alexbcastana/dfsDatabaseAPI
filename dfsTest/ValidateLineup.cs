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
    public class ValidateLineup
    {
        LineupInfo lineup = new LineupInfo
        {
            Budget = 60000,
            NumCenters = 0,
            NumPFs = 0,
            NumPGs = 0,
            NumSFs = 0,
            NumSGs = 0,
            SalarySum = 0,
            TotalPlayers = 0,
            IsValid = "NOT VALID"
        };
        public ValidateLineup()
        {
            Init();
        }
        private async void Init()
        {

            var players = await DocumentDBRepository<Player>.GetPlayersAsync(d => (d.InLineup));
            foreach (Player player in players)
            {
                if (player.Position == "PF")
                    lineup.NumPFs++;
                else if (player.Position == "SF")
                    lineup.NumSFs++;
                else if (player.Position == "C")
                    lineup.NumCenters++;
                else if (player.Position == "PG")
                    lineup.NumPGs++;
                else if (player.Position == "SG")
                    lineup.NumSGs++;
                lineup.SalarySum = lineup.SalarySum + player.Salary;
            }
            lineup.TotalPlayers = lineup.NumCenters + lineup.NumPFs + lineup.NumPGs + lineup.NumSGs + lineup.NumSFs;
            if (lineup.SalarySum < lineup.Budget && lineup.NumSGs <= 2 && lineup.NumSFs <= 2 && lineup.NumPFs <= 2 && lineup.NumPGs <= 2 && lineup.NumCenters <= 2 && lineup.TotalPlayers <= 9)
            {
                lineup.IsValid = "VALID";
            }
        }
        public LineupInfo GetLineup()
        {
            return lineup;
        }
    }
}