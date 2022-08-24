namespace ToDoAplication.Models
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Todo { get; set; }
        public string? Comment { get; set; }
        public DateTime? Date { get; set; }
        public bool? status { get; set; }
    }
}
