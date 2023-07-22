using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories.Contracts
{
    public interface IStudentRepository : IRepository
    {
        public DbSet<Student> Students { get; }
    }
}
