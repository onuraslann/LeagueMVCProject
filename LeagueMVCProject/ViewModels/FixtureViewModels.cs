using LeagueMVCProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueMVCProject.ViewModels
{
    public class FixtureViewModels
    {
        public List<Teams> Teams { get; set; }

        public Fixtures Fixtures { get; set; }
    }
}