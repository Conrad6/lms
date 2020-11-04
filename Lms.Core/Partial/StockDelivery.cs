namespace Lms.Core
{
    public partial class StockDelivery
    {
        protected bool Equals(StockDelivery other)
        {
            return Id == other.Id && StockId == other.StockId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StockDelivery) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (StockId != null ? StockId.GetHashCode() : 0);
            }
        }
    }
}