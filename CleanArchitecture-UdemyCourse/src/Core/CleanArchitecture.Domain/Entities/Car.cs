using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities;

public sealed class Car : Entity
{

    public string Name { get; set; }

    public string Model { get; set; }

    public int EnginePower { get; set; }
}
