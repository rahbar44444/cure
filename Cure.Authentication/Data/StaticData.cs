namespace Cure.Authentication.Data
{
    public static class StaticData
    {
        public static List<UsersMaster> UserList = new();
        public static List<RolesMaster> RoleList = new();
        public static List<UserRoles> UserRoleList = new();
        public static List<RegionMaster> RegionList = new();
        public static List<RoleRegions> RoleRegionList = new();

        static StaticData()
        {
            #region Load users
            
            UserList.Add(new UsersMaster
            {
                UserId = 1,
                FirstName = "Rahbar",
                LastName = "Khan",
                UserName = "rahbar",
                Password = "rahbar",
                Email = "rahbar@gmail.com",
                PhoneNumber = "+917644006511",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                //UserRoles = new List<UserRoles>
                //{
                //    new UserRoles{ UserId = 1, RoleId =1 ,Role = new RolesMaster{ RoleId=1, RoleName = "player", CreatedOn = DateTime.Now, UpdatedOn=DateTime.Now } },
                //    new UserRoles{ UserId = 2, RoleId =2 ,Role = new RolesMaster{ RoleId=2, RoleName = "admin", CreatedOn = DateTime.Now, UpdatedOn=DateTime.Now } }
                //}
                
            }) ;
             ;

            UserList.Add(new UsersMaster
            {
                UserId = 2,
                FirstName = "Aman",
                LastName = "Khan",
                UserName = "aman",
                Password = "aman",
                Email = "aman@gmail.com",
                PhoneNumber = "+917644006511",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                UserRoles = new List<UserRoles>
                {
                    new UserRoles{ UserId = 2, RoleId =2 ,Role = new RolesMaster{ RoleId=2, RoleName = "admin", CreatedOn = DateTime.Now, UpdatedOn=DateTime.Now } }
                }
            });

            #endregion Load users

            #region Load roles

            RoleList.Add(
                new RolesMaster
                {
                    RoleId = 1,
                    RoleName = "player",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                });
            RoleList.Add(new RolesMaster
            {
                RoleId = 2,
                RoleName = "admin",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            });

            #endregion Load roles

            #region Load user roles

            UserRoleList.Add(
                new UserRoles
                {
                    UserId = 1,
                    RoleId = 1
                });
            UserRoleList.Add(new UserRoles
            {
                UserId = 1,
                RoleId = 2
            });
            UserRoleList.Add(
            new UserRoles
            {
                UserId = 2,
                RoleId = 2
            });


            #endregion Load user roles

            #region Load regions

            RegionList.Add(new RegionMaster
            {
                RegionId = 1,
                RegionName = "b_game",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            });
            RegionList.Add(new RegionMaster
            {
                RegionId = 2,
                RegionName = "vip_chararacter_personaliz",
                UpdatedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            });

            #endregion Load regions

            #region Load Role regions

            RoleRegionList.Add(new RoleRegions
            {
                RoleId = 1,
                RegionId = 1
            });

            RoleRegionList.Add(new RoleRegions
            {
                RoleId = 2,
                RegionId = 2
            });

            #endregion Load Role regions
        }
    }
}
