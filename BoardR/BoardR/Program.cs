
namespace BoardR
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                var log = new EventLog("An important thing happened");
                Console.WriteLine(log.Description); // An important thing happened
                Console.WriteLine(log.ViewInfo());  // [20200125|14:02:59.0361]An important thing happened

                // if you uncomment any of the next two lines, compilation error must occur! (e.g. use readonly properties)
                // log.Description = "new desc";
                // log.Time = DateTime.Now;

                var log2 = new EventLog(null);



            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            



        }
    }
}