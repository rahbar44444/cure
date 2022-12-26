using Cure.Authentication.Data;

namespace Cure.Authentication.Services
{
    public interface ICureRepository
    {
        public List<UsersMaster> GetUsers();
        public List<RolesMaster> GetRoles();
        public List<RolesMaster> GetUserRoles(long userId);
        public List<RegionMaster> GetUserRegions(long userId);
    }
}
