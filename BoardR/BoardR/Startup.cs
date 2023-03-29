
using BoardR.Loggers;

namespace BoardR
{
    internal class Startup
    {
        
        static void Main(string[] args)
        {
            var tomorrow = DateTime.Now.AddDays(1);
            BoardItem task = new Task("Write unit tests", "Peter", tomorrow);
            BoardItem issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

            Console.WriteLine(task.ViewInfo());
            Console.WriteLine(issue.ViewInfo());
            
        }
    }
}