using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dfsTest.Models
{
    public class LineupInfo
    {
        public int Budget { get; set; }
        public int NumCenters { get; set; }
        public int NumPGs { get; set; }
        public int NumSGs { get; set; }
        public int NumSFs { get; set; }
        public int NumPFs { get; set; }
        public int TotalPlayers { get; set; }
        public int SalarySum { get; set; }
        public String IsValid { get; set; }
    }
}