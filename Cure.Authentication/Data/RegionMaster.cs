namespace Cure.Authentication.Data
{
    public partial class RegionMaster
    {
        public RegionMaster()
        {
            RoleRegions = new HashSet<RoleRegions>();
        }

        public long RegionId { get; set; }
        public string RegionName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<RoleRegions> RoleRegions { get; set; }
    }
}
