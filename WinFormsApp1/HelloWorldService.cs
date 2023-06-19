using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDiWinFormsApp1
{
    public interface IHelloWorldService
    {
        string DoWork();
    }

    public class HelloWorldServiceImpl : IHelloWorldService
    {
        public string DoWork()
        {
            return "hello world service::do work";
        }
    }

}
