using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp
{

    public class MyConfigurationBuilder
    {
        class MyConfiguration : MyApplicationConfiguration
        {

        }
        public MyApplicationConfiguration BuildConfiguration(int size, string name)
        {
            var obj = new MyConfiguration();
            obj.Size = size;
            obj.Label = name;
            return obj;
        }
    }
}
namespace SolidApp
{
    class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Work in Employee");
        }
    }
    class Consultant : Employee
    {
        public override void Work()
        {
            base.Work();
            Console.WriteLine("Work as consultant");
        }
        public void DoMoreWork()
        {
            Console.WriteLine("Do more work in Consulant");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Consultant();
            employee.Work();
            ((Consultant)employee).DoMoreWork();//cast to call the additional method
            MyApplicationConfiguration configuration = new MyConfigurationBuilder().BuildConfiguration(10, "Sample");
        }
    }
}

