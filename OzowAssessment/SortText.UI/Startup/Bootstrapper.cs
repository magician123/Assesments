using Autofac;
using SortText.Interfaces;

namespace SortText.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SortText>().AsSelf();
            builder.RegisterType<FormatText>().As<IFormatText>();

            return builder.Build();
        }
    }
}
