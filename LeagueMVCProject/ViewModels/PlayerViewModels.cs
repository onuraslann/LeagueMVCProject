using LeagueMVCProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueMVCProject.ViewModels
{
    public class PlayerViewModels
    {

        public List<Teams> Teams { get; set; }
        public List<Leagues> Leagues { get; set; }
        public Players Players { get; set; }
    }
}