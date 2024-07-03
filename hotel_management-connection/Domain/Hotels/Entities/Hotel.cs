namespace Domain.Hotels.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime OpenSince { get; set; }

    public Hotel(string name, string address, DateTime openSince)
    {
        Name = name;
        Address = address;
        OpenSince = openSince;
    }

    public Hotel(int id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }

    /// <summary>
    /// for ef
    /// </summary>
    private Hotel()
    {
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
        }

        Name = name;
    }

    public void SetAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentException($"'{nameof(address)}' cannot be null or whitespace.", nameof(address));
        }

        Address = address;
    }

    public void CopyFrom(Hotel other)
    {
        SetName(other.Name);
        SetAddress(other.Address);
    }
}
