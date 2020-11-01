namespace Lms.Core
{
    public partial class CustomerSubscription
    {
        protected bool Equals(CustomerSubscription other)
        {
            return Id == other.Id && CustomerId == other.CustomerId && SubscriptionId == other.SubscriptionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((CustomerSubscription) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CustomerId != null ? CustomerId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SubscriptionId != null ? SubscriptionId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}