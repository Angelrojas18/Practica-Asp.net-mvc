namespace prueba_mvc.Models.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
