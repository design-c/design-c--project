using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Contracts.Models;

public class BaseModel<TType>
{
    [Key]
    [Column("Id")]
    public TType Id { get; set; } 
}