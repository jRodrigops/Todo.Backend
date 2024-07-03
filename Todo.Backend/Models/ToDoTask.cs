using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Backend.Models;

public class ToDoTask
{
    [Key]
    [Column("id_task")]
    [Required]
    public int idTask { get; set; }

    [Column("description")]
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Description { get; set; }

    [Column("completed")]
    public bool Completed { get; set; } = false;
}
