namespace Lms.Core
{
    public partial class Subscription
    {
        protected bool Equals(Subscription other)
        {
            return Id == other.Id && NormalizedName == other.NormalizedName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Subscription) obj);
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