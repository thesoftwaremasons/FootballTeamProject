using System.ComponentModel.DataAnnotations;

namespace FootballTeamProject.Web.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
