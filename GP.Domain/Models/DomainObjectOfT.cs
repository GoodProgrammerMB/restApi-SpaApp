using System.Collections.Generic;

namespace GP.Domain.Models
{
    public abstract class DomainObject<TId> : IDomainObject
    {
        public TId Id { get; set; }

        public virtual bool IsTransient => Id == null || this.Id.Equals(default(TId));

        public override bool Equals(object obj)
        {
            var other = obj as DomainObject<TId>;

            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            if (other == null) return false;
            if (this.IsTransient && !other.IsTransient) return false;
            if (!this.IsTransient && other.IsTransient) return false;

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }

        public static bool operator ==(DomainObject<TId> first, DomainObject<TId> second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return true;

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                return false;

            return first.Equals(second);
        }

        public static bool operator !=(DomainObject<TId> first, DomainObject<TId> second)
        {
            return !(first == second);
        }
    }
}
