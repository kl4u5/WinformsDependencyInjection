
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestDiWinFormsApp1
{
    //Dependency injection that works for [STAThread] forms
    //OpenfileDialog etc. will no get STA errro.
    //https://www.wiktorzychla.com/2022/01/winforms-dependency-injection-in-net6.html
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var formFactory = CompositionRoot();
            ApplicationConfiguration.Initialize();
            Application.Run(formFactory.CreateForm1());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IHelloWorldService, HelloWorldServiceImpl>();
                    services.AddTransient<Form1>();
                    services.AddTransient<Func<string, Form2>>(
                        container =>
                            something =>
                            {
                                var helloWorldService =
                                    container.GetRequiredService<IHelloWorldService>();
                                return new Form2(helloWorldService, something);
                            });
                });
        }

        static IFormFactory CompositionRoot()
        {
            // host
            var hostBuilder = CreateHostBuilder();
            var host = hostBuilder.Build();

            // container
            var serviceProvider = host.Services;

            // form factory
            var formFactory = new FormFactoryImpl(serviceProvider);
            FormFactory.SetProvider(formFactory);

            return formFactory;
        }
    }

    public class FormFactoryImpl : IFormFactory
    {
        private IServiceProvider _serviceProvider;

        public FormFactoryImpl(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public Form1 CreateForm1()
        {
            return _serviceProvider.GetRequiredService<Form1>();
        }

        public Form2 CreateForm2(string something)
        {
            var _form2Factory = _serviceProvider.GetRequiredService<Func<string, Form2>>();
            return _form2Factory(something);
        }
    }
}