using FootballTeamProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamProject.Core.Model
{
    public class Team:BaseEntity
    {
        public string TeamName { get; set; }
        public DateTime DateFounded { get; set; }
        public string TeamLogo { get; set; }
        public string OwnersName { get; set; }
        public string ShortDescription { get; set; }
    }
}
