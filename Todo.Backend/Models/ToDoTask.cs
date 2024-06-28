using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Backend.Models;

public class ToDoTask
{
    [Column("id_task")]
    [Required]
    public  int idTarefa { get; set; }

    [Column("description")]
    [Required]
    public string Description { get; set; }
}
