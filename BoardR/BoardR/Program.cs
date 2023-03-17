
namespace BoardR
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                
                var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
                
                var anotherItem = new BoardItem("Encrypt user data", DateTime.Now.AddDays(10));

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
                item.AdvanceStatus();
               /* Board.Items.Add(item);
                Board.Items.Add(anotherItem);
                foreach (var boardItem in Board.Items)
                {
                    boardItem.AdvanceStatus();
                }

                foreach (var boardItem in Board.Items)
                {*/
                /*    Console.WriteLine(boardItem.ViewInfo());
                }*/

            // Output:
            // 'Refactor this mess', [InProgress|25-01-2020]
            // 'Encrypt user data', [Todo|02-02-2020]

        }
            catch (ArgumentNullException exception)
            {

                Console.WriteLine(exception.Message);
            }


}
    }
}