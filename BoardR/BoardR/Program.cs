
namespace BoardR
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
                Console.WriteLine(item.Title); // Refactor this mess
                Console.WriteLine(item.DueDate); // 25/01/2020 12:09:49 PM (this will vary depending on when you run the code)
                Console.WriteLine(item.Status); // Open            
                item.AdvanceStatus();
                Console.WriteLine(item.Status); // Todo
                item.AdvanceStatus();
                Console.WriteLine(item.Status); // InProgress
                item.RevertStatus();
                Console.WriteLine(item.Status); // Todo
                Console.WriteLine(item.ViewInfo()); // 'Refactor this mess', [Open|25-01-2020]
                item.
                item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
                item.AdvanceStatus();
                var anotherItem = new BoardItem("Encrypt user data", DateTime.Now.AddDays(10));                
                var errorDueDateItem = new BoardItem("Encrypt user data", DateTime.Now.AddDays(0));

                Board.items.Add(item);
                Board.items.Add(anotherItem);

                foreach (var boardItem in Board.items)
                {
                    boardItem.AdvanceStatus();
                }

                foreach (var boardItem in Board.items)
                {
                    Console.WriteLine(boardItem.ViewInfo());
                }

                // Output:
                // 'Refactor this mess', [InProgress|25-01-2020]
                // 'Encrypt user data', [Todo|02-02-2020]

            }            
            catch (ArgumentException exception)
            {

                Console.WriteLine(exception.Message);
            }
            





        }
    }
}