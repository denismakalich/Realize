namespace Domain.Models.Locations;

public class Coordinat
{
    public float Width { get; set; }
    public float Longitude { get; set; }

    public Coordinat(float width, float longitude)
    {
        Width = width;
        Longitude = longitude;
    }
}