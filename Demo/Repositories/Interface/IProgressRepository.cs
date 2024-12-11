using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface IProgressRepository
    {
        public Task UpdateProgressAsync(int studentId);
        public  Task UpdateProgressForAllStudentsAsync();

    }
}
