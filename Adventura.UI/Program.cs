using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            UIService service = new UIService();
            UI UI = new UI(service);

            UI.Run();
            UI.Menu();
        }
    }
}