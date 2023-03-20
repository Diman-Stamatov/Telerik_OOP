
namespace BoardR
{
    internal class Startup
    {
        
        static void Main(string[] args)
        {
            /*try
            {
                var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
                item.DueDate = item.DueDate.AddYears(2);
                item.Title = "Not that important";
                item.RevertStatus();
                item.AdvanceStatus();
                item.RevertStatus();

                Console.WriteLine(item.ViewHistory());

                Console.WriteLine("\n--------------\n");

                var anotherItem = new BoardItem("Don't refactor anything", DateTime.Now.AddYears(10));
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                anotherItem.AdvanceStatus();
                Console.WriteLine(anotherItem.ViewHistory());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }*/
            var task = new Task("Test the application flow", "Peter", DateTime.Now.AddDays(1));
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.Assignee = "George";
            Console.WriteLine(task.ViewHistory());










        }
    }
}