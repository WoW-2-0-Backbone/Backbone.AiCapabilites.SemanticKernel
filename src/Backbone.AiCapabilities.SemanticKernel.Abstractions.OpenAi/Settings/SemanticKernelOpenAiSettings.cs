namespace Backbone.AiCapabilities.SemanticKernel.Abstractions.OpenAi.Settings;

/// <summary>
/// Represents OpenAI settings for Semantic Kernel Integration.
/// </summary>
public sealed record SemanticKernelOpenAiSettings
{
    /// <summary>
    /// Gets the API key.
    /// </summary>
    public string ApiKey { get; init; } = default!;

    /// <summary>
    /// Gets OpenAI model ID.
    /// </summary>
    public string ModelId { get; init; } = default!;
}