namespace Repositories.Contracts
{
    // combine respositories at one place.
    public interface ICMSRepository :
        IClassroomRepository,
        IStudentRepository
    {
    }
}
