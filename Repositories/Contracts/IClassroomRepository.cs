using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories.Contracts
{
    public interface IClassroomRepository : IRepository
    {
        public DbSet<Classroom> Classrooms { get; }
    }
}
