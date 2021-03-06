﻿namespace Lms.Core
{
    public partial class CustomerSubscription
    {
        protected bool Equals(CustomerSubscription other)
        {
            return Id == other.Id && SubscriptionId == other.SubscriptionId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CustomerSubscription) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (SubscriptionId != null ? SubscriptionId.GetHashCode() : 0);
            }
        }
    }
}