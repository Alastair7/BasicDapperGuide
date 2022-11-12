namespace Basic.Dapper.Tutorial.ProjectService.Entities
{
    public class ProjectEntity
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public int MemberId { get; set; }

    }
}
