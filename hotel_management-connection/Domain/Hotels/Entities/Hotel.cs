namespace Domain.Hotels.Entities;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime OpenSince { get; set; }
    public Hotel()
    {
    }

    public void Update(Hotel hotel)
    {
        Name = hotel.Name;
        Address = hotel.Address;
    }
}

