namespace Services.DTOs
{
    public record class ClassroomDTO
    {
        public Guid Id { get; set; }
        public int ClassroomNumber { get; set; }

        public virtual IList<StudentDTO>? Students { get; set; }

        //public sealed record class Create
        //{
        //    public int ClassroomNumber { get; set; }
        //}
    }

    public sealed record class ClassroomCreateDTO
    {
        public int ClassroomNumber { get; set; }
    }
}
