using System;

namespace StruttonTechnologies.Core.ToolKit.Registration.Models
{
    /// <summary>
    /// Defines how service collection composition handles duplicate service registrations.
    /// </summary>
    public enum ServiceCompositionBehavior
    {
        /// <summary>
        /// Adds all descriptors from the source collection to the target collection.
        /// </summary>
        Append = 0,

        /// <summary>
        /// Skips a source descriptor when the target collection already contains the same service type.
        /// </summary>
        SkipExistingServiceType = 1,

        /// <summary>
        /// Removes existing descriptors for the same service type before adding the source descriptor.
        /// </summary>
        ReplaceExistingServiceType = 2,

        /// <summary>
        /// Throws an exception when the target collection already contains the same service type.
        /// </summary>
        ThrowIfServiceTypeExists = 3
    }
}
