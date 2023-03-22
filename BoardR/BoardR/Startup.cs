
namespace BoardR
{
    internal class Startup
    {
        
        static void Main(string[] args)
        {
            

            var task = new Task("Test the application flow", "Peter", DateTime.Now.AddDays(1));
            task.RevertStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.Assignee = "George";
            Console.WriteLine(task.ViewHistory());
            Console.WriteLine();

            var issue = new Issue("App flow tests?", "We need to test the App!", DateTime.Now.AddDays(1));
            issue.RevertStatus();
            issue.AdvanceStatus();
            issue.AdvanceStatus();
            issue.AdvanceStatus();
            issue.AdvanceStatus();
            issue.AdvanceStatus();
            issue.DueDate = issue.DueDate.AddDays(1);
            Console.WriteLine(issue.ViewHistory());


        }
    }
}