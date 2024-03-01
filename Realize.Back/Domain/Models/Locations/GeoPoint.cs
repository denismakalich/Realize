namespace Domain.Models.Locations;

public class GeoPoint
{
    public float Latitude { get; set; }
    public float Longitude { get; set; }

    public GeoPoint(float latitude, float longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}