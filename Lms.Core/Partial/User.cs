namespace Lms.Core
{
    public partial class User
    {
        protected bool Equals(User other)
        {
            return Id == other.Id && Username == other.Username;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (Username != null ? Username.GetHashCode() : 0);
            }
        }
    }
}