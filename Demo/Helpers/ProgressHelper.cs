using Demo.Data;

namespace Demo.Helpers
{
    public class ProgressHelper
    {
        public static double CalculateCompletionPercentage(IEnumerable<StudentLesson> lessons)
        {
            if (lessons == null || !lessons.Any())
            {
                return 0;
            }

            var completedLessons = lessons.Count(l => l.IsCompleted);
            return (completedLessons / (double)lessons.Count()) * 100;
        }
    }
}
