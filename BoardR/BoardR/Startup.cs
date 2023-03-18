
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

            
            try
            {
                var item1 = new BoardItem("Implement login/logout", DateTime.Now.AddDays(3));
                var item2 = new BoardItem("Secure admin endpoints", DateTime.Now.AddDays(5));

                Board.AddItem(item1); // add item1
                Board.AddItem(item2); // add item2
                 // do nothing - item1 already in the list
                 // do nothing - item2 already in the list

                int count = Board.TotalItems;
                Console.WriteLine(count);
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            




        }
    }
}