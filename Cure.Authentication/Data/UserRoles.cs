namespace Cure.Authentication.Data
{
    public partial class UserRoles
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        public virtual RolesMaster Role { get; set; }
        public virtual UsersMaster User { get; set; }
    }
}
