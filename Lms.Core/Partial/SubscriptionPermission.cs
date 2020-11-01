namespace Lms.Core
{
    public partial class SubscriptionPermission
    {
        protected bool Equals(SubscriptionPermission other)
        {
            return Id == other.Id && SubscriptionId == other.SubscriptionId && PermissionId == other.PermissionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SubscriptionPermission) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SubscriptionId != null ? SubscriptionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PermissionId != null ? PermissionId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}