using Backbone.AiCapabilities.SemanticKernel.Abstractions.OpenAi.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace Backbone.AiCapabilities.SemanticKernel.Abstractions.OpenAi.Configurations;

/// <summary>
/// Provides extension methods to configure the semantic kernel.
/// </summary>
public static class InfraConfigurations
{
    /// <summary>
    /// Configures the Semantic Kernel integration using OpenAI model.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="configuration">The IConfiguration instance.</param>
    /// <param name="configureKernel">Configuration for additional customization.</param>
    /// <returns>The IServiceCollection for chaining.</returns>
    public static IServiceCollection AddSemanticKernelWithOpenAi(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<IKernelBuilder, IServiceCollection, IConfiguration>? configureKernel = default
    )
    {
        services.Configure<SemanticKernelOpenAiSettings>(configuration.GetSection(nameof(SemanticKernelOpenAiSettings)));

        var kernelBuilder = Kernel.CreateBuilder();
        configureKernel?.Invoke(kernelBuilder, services, configuration);
        var kernel = kernelBuilder.Build();
        
        // Add Semantic Kernel
        services.AddSingleton(kernel);

        return services;
    }
}