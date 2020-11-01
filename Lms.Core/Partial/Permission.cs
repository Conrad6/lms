namespace Lms.Core
{
    public partial class Permission
    {
        protected bool Equals(Permission other)
        {
            return Id == other.Id && NormalizedName == other.NormalizedName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Permission) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^
                       (NormalizedName != null ? NormalizedName.GetHashCode() : 0);
            }
        }
    }
}