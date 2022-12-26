using Cure.Authentication.Data;

namespace Cure.Authentication.Services
{
    public class CureRepository : ICureRepository
    {
        public CureRepository()
        {
           
        }

        public List<UsersMaster> GetUsers()
        {
            return StaticData.UserList;
        }
                public List<RolesMaster> GetRoles()
        {
            return StaticData.RoleList;
        }
        public List<RolesMaster> GetUserRoles(long userId)
        {           

                 List<RolesMaster> roles = (from ul in StaticData.UserList
                                                   join ur in StaticData.UserRoleList on ul.UserId equals ur.UserId
                                                   join rl in StaticData.RoleList on ur.RoleId equals rl.RoleId
                                                   where ul.UserId == userId
                                                   select rl).Distinct().ToList();

            return roles;
        }

        public List<RegionMaster> GetUserRegions(long userId)
        {
            List<RegionMaster> regions = (from ul in StaticData.UserList
                                       join ur in StaticData.UserRoleList on ul.UserId equals ur.UserId
                                       join rl in StaticData.RoleList on ur.RoleId equals rl.RoleId
                                       join rrgl in StaticData.RoleRegionList on rl.RoleId equals rrgl.RoleId
                                       join rgl in StaticData.RegionList on rrgl.RegionId equals rgl.RegionId
                                       where ul.UserId == userId
                                       select rgl).Distinct().ToList();

            return regions;
        }
    }
}
