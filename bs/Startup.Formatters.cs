namespace bs
{
    using Boilerplate.Web.Mvc.Formatters;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Serialization;

    public partial class Startup
    {
        /// <summary>
        /// Configures the input and output formatters.
        /// </summary>
        private static void ConfigureFormatters(IMvcBuilder mvcBuilder)
        {
            // The JSON input and output formatters are added to MVC by default.
        }
    }
}
