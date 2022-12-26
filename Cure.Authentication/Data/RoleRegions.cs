namespace Cure.Authentication.Data
{
    public partial class RoleRegions
    {
        public long RoleId { get; set; }
        public long RegionId { get; set; }

        public virtual RolesMaster Role { get; set; }
        public virtual RoleRegions Region { get; set; }
    }
}
