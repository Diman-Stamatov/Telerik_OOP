
namespace BoardR
{
    internal class Startup
    {
        
        static void Main(string[] args)
        {

            var tomorrow = DateTime.Now.AddDays(1);
            var issue = new Issue("App flow tests?", "We need to test the App!", tomorrow);

            issue.RevertStatus();
            issue.AdvanceStatus();
            issue.AdvanceStatus();
            issue.RevertStatus();

            Console.WriteLine(issue.ViewHistory());



        }
    }
}