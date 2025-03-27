public class Customer
{
    public string CustomerId { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    public Customer() { } // 无参构造函数
    public Customer(string customerId, string name, string contactInfo)
    {
        CustomerId = customerId;
        Name = name;
        ContactInfo = contactInfo;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Customer other = (Customer)obj;
        return CustomerId == other.CustomerId;
    }

    public override int GetHashCode()
    {
        return CustomerId.GetHashCode();
    }

    public override string ToString()
    {
        return $"Customer ID: {CustomerId}, Name: {Name}, Contact: {ContactInfo}";
    }
}