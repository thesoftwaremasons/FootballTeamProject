using FootballTeamProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamProject.Core.Model
{
    public class UserTeam: BaseEntity
    {
        public UserProfile user { get; set; }
        public Team team { get; set; }
    }
}
