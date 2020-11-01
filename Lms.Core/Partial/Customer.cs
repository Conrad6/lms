namespace Lms.Core
{
    public partial class Customer
    {
        protected bool Equals(Customer other)
        {
            return Id == other.Id && NatId == other.NatId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (NatId != null ? NatId.GetHashCode() : 0);
            }
        }
    }
}