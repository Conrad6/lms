﻿namespace Lms.Core
{
    public partial class BorrowCheckoutItem
    {
        protected bool Equals(BorrowCheckoutItem other)
        {
            return Id == other.Id && BorrowCheckoutId == other.BorrowCheckoutId && BookId == other.BookId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BorrowCheckoutItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BorrowCheckoutId != null ? BorrowCheckoutId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BookId != null ? BookId.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}