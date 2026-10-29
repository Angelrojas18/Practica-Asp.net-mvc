using System.ComponentModel.DataAnnotations;

namespace prueba_mvc.Models.Entities
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public int Descripcion { get; set; }
        public required string Titulo { get; set; }
        public DateTime FechadeCreacion { get; set; } =  DateTime.Now;
        public DateTime? FechaDevencimiento { get; set; } = DateTime.Now;
        public bool Completada { get; set; } = false;

        public int CategoryId { get; set; }
        public  Category Category { get; set; } = null;




    }
}
