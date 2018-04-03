namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Lizards.Data.CQRS;
    using Lizards.Data.CQRS.DataAccess;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Automatic registration of all CQRS required items
    /// </summary>
    public sealed class CQRSShard : ShardBase<IEnumerable<string>>
    {
        protected override void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env, IEnumerable<string> arguments)
            => app
                .ApplicationServices
                .GetService<IDataContextInitialiser>()
                .Initialise()
                .Wait();

        protected override void ConfigureServices(IServiceCollection services, IEnumerable<string> arguments)
        {
            arguments
                .Select(assemblyName => Assembly.Load(new AssemblyName(assemblyName)))
                .ToList()
                .ForEach(assembly => this.AutomaticDetection(services, assembly));
        }

        private void AutomaticDetection(IServiceCollection services, Assembly assembly)
            => services
                .DiscoverImplementation()
                    .ForAssembly(assembly)
                    .IncludeClassesOnly()
                    .ForTypesImplementingInterface<IDataContext>()
                    .AddAsInterface<IDataContext>()
                .DiscoverImplementation()
                    .ForAssembly(assembly)
                    .IncludeClassesOnly()
                    .ForTypesImplementingInterface<IDataContextInitialiser>()
                    .AddAsInterface<IDataContextInitialiser>()
                .DiscoverImplementation()
                    .ForAssembly(assembly)
                    .IncludeClassesOnly()
                    .ForTypesImplementingInterface(typeof(ICommandHandler))
                    .AddAsInterface<ICommandHandler>()
                .DiscoverImplementation()
                    .ForAssembly(assembly)
                    .IncludeClassesOnly()
                    .ForTypesImplementingInterface<IsQuery>()
                    .AsSelf()
                .DiscoverImplementation()
                    .ForAssembly(assembly)
                    .IncludeClassesOnly()
                    .ForTypesImplementingInterface<IStory>()
                    .AsImplementedInterfaces();
    }
}