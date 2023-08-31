namespace ProjectsApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RepositoryUrl { get; set; }
        public string TechnologiesUsed { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
