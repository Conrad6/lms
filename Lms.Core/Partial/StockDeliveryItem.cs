namespace Lms.Core
{
    public partial class StockDeliveryItem
    {
        protected bool Equals(StockDeliveryItem other)
        {
            return Id == other.Id && StockDeliveryId == other.StockDeliveryId && BookId == other.BookId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StockDeliveryItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StockDeliveryId != null ? StockDeliveryId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BookId != null ? BookId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}