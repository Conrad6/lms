namespace Lms.Core
{
    public partial class BookTag
    {
        protected bool Equals(BookTag other)
        {
            return Id == other.Id && BookId == other.BookId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((BookTag) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (BookId != null ? BookId.GetHashCode() : 0);
            }
        }
    }
}