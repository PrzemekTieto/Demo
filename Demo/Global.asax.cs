using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Emgu.CV;
using ImageAcquisitionModule;
using ImageAcquisitionModule.Contract;
using Services;
using Services.Contract;

namespace Demo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //TODO: Register types for DI here
            builder.RegisterType<ImageService>().As<IImageService>();
            builder.RegisterType<CameraCapture>().As<IImageAcquisition>();
            builder.RegisterType<VideoCapture>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
