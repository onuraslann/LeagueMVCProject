//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LeagueMVCProject.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fixtures
    {
        public int Id { get; set; }
        public Nullable<int> HomeTeamId { get; set; }
        public Nullable<int> GuestTeamId { get; set; }
        public Nullable<System.DateTime> MatchDate { get; set; }
    
        public virtual Teams Teams { get; set; }
        public virtual Teams Teams1 { get; set; }
    }
}