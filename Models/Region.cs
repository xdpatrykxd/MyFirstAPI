using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Climate { get; set; }
}