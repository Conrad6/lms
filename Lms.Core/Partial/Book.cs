using System;
using System.Collections.Generic;

namespace Lms.Core
{
    public partial class Book
    {
        protected bool Equals(Book other)
        {
            return Id == other.Id && Isbn == other.Isbn;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (Isbn != null ? Isbn.GetHashCode() : 0);
            }
        }
    }
}