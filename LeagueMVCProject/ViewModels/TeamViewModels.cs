using LeagueMVCProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueMVCProject.ViewModels
{
    public class TeamViewModels
    {
        public List<Leagues> Leagues { get; set; }
        public Teams Teams { get; set; }
    }
}