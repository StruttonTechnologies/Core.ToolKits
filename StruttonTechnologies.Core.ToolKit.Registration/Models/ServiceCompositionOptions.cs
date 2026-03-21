using System;

namespace StruttonTechnologies.Core.ToolKit.Registration.Models
{
    /// <summary>
    /// Represents configuration options for composing one <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/>
    /// into another.
    /// </summary>
    public sealed class ServiceCompositionOptions
    {
        /// <summary>
        /// Gets or sets the duplicate-handling behavior to apply during composition.
        /// </summary>
        public ServiceCompositionBehavior Behavior { get; set; } = ServiceCompositionBehavior.Append;

        /// <summary>
        /// Gets or sets an optional logger used to record composition actions.
        /// </summary>
        public Action<string>? Logger { get; set; }
    }
}
