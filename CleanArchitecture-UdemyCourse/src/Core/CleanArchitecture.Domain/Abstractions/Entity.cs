using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Abstractions;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid().ToString();        
    }

    public string Id { get; set; }
    public DateTime CreateDate{ get; set; }
    public DateTime? UpdateDate { get; set; }
}
