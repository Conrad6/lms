namespace Lms.Core
{
    public partial class BorrowCheckout
    {
        protected bool Equals(BorrowCheckout other)
        {
            return Id == other.Id && BorrowId == other.BorrowId && CheckoutIssuerId == other.CheckoutIssuerId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((BorrowCheckout) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BorrowId != null ? BorrowId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CheckoutIssuerId != null ? CheckoutIssuerId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}