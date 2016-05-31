using System;

namespace MatchingEngine.Model
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public Product(int id, string name, decimal price = 0, string currency = null)
        {
            Id = id;
            Name = name;
            Price = price;
            Currency = currency;
        }

        public bool Equals(Product other)
        {
            if(other == null)
            {
                return false;
            }

            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Product))
            {
                throw new InvalidCastException(string.Format("obj is not a {0}", this.GetType().FullName));
            }
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2} {3}", Id, Name, Price, Currency);
        }

        public static bool operator == (Product product1, Product product2)
        {
            if (ReferenceEquals(product1, null))
            {
                return ReferenceEquals(product2, null);
            }

            return product1.Equals(product2);
        }

        public static bool operator !=(Product product1, Product product2)
        {
            if (ReferenceEquals(product1, null))
            {
                return !ReferenceEquals(product2, null);
            }

            return !product1.Equals(product2);
        }
    }
}
