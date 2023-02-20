using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamProject.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid PId { get; set; }
        public DateTime DateCreated { get; set; }
        public string EnteredBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
