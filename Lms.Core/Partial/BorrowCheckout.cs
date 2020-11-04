namespace Lms.Core
{
    public partial class BorrowCheckout
    {
        protected bool Equals(BorrowCheckout other)
        {
            return Id == other.Id && BorrowId == other.BorrowId && StockId == other.StockId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BorrowCheckout) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BorrowId != null ? BorrowId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StockId != null ? StockId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}