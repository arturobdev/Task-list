using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskList.DTOs;

namespace TaskList.Entities
{
    [Table("tasks")]
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("task_id")]
        public int Id { get; set; }
        [Column("task_title", TypeName = "VARCHAR(100)")]
        [Required]
        public string Title { get; set; }

        [Column("title_description", TypeName = "VARCHAR(100)")]
        public string Description { get; set; }

        [Column("is_completed")]
        public bool IsCompleted { get; set; }


        public static implicit operator Todo(TaskDTO v)
        {
            var todo = new Todo();
            todo.Title = v.Title;
            todo.Description = v.Description;
            todo.IsCompleted = v.IsCompleted;
            return todo;
        }
    }
}
