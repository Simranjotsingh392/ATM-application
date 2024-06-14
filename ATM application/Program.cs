using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ATM_application
{
    class Program
{
    static void Main(string[] args)
    {
        AtmApplication atmApplication = new AtmApplication();

        atmApplication.execute();
        Console.WriteLine("\n\n---------------------------------");
        Console.WriteLine("\n\nThank You for using the Application");
        Console.WriteLine("\n\n---------------------------------");
    }
}
}