using FootballTeamProject.Web.Helpers;


namespace FootballTeamProject.Web.ViewModels
{
    public class ManageUserPermissionsViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PermissionValue { get; set; }
        public PaginatedList<ManageUserClaimViewModel> ManagePermissionsViewModel { get; set; }
    }
}
