using System.ComponentModel.DataAnnotations;

namespace Sample_CRUD.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 



    }
}
