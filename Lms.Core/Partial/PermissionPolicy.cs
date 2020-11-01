namespace Lms.Core
{
    public partial class PermissionPolicy
    {
        protected bool Equals(PermissionPolicy other)
        {
            return Id == other.Id && PermissionId == other.PermissionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PermissionPolicy) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^
                       (PermissionId != null ? PermissionId.GetHashCode() : 0);
            }
        }
    }
}