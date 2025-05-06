using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int RegionId { get; set; }
}