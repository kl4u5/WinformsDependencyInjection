using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDiWinFormsApp1
{
    public interface IFormFactory
    {
        Form1 CreateForm1();
        Form2 CreateForm2(string something);
    }

    public class FormFactory : IFormFactory
    {
        static IFormFactory _provider;

        public static void SetProvider(IFormFactory provider)
        {
            _provider = provider;
        }

        public Form1 CreateForm1()
        {
            return _provider.CreateForm1();
        }

        public Form2 CreateForm2(string something)
        {
            return _provider.CreateForm2(something);
        }
    }

}
