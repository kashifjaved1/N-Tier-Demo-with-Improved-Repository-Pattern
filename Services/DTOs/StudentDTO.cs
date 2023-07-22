namespace Services.DTOs
{
    public record StudentDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid ClassroomId { get; set; }

        //public sealed record class Create
        //{
        //    public string? Name { get; set; }
        //    public Guid ClassroomId { get; set; }
        //}
    }

    public sealed record class StudentCreateDTO
    {
        public string? Name { get; set; }
        public Guid ClassroomId { get; set; }
    }
}
