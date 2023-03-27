
namespace BoardR
{
    internal class Startup
    {
        
        static void Main(string[] args)
        {

            var tomorrow = DateTime.Now.AddDays(1);
            var task = new Task("Write unit tests", "Peter", tomorrow);
            var issue = new Issue("Review tests", "Someone must review Peter's tests.", tomorrow);

            Board.AddItem(task);
            Board.AddItem(issue);
            task.AdvanceStatus();
            task.RevertStatus();
            task.RevertStatus();
            task.RevertStatus();
            issue.AdvanceStatus();
            issue.AdvanceStatus();
            issue.RevertStatus();
            issue.RevertStatus();

            Board.LogHistory();


        }
    }
}