# StruttonTechnologies.Core.ToolKit.Registration

A lightweight service-collection composition library for StruttonTechnologies applications.

This package is intentionally focused on composing `IServiceCollection` instances. It does not rely on attribute scanning or automatic registration. The design favors explicit composition so modules can register services locally and then pass those registrations upward to a parent composition root.

## Features

- Compose one `IServiceCollection` into another
- Compose multiple source collections into a single target collection
- Control duplicate handling with explicit composition behavior
- Optional logging for diagnostics during composition
- Dependency-light design based on `Microsoft.Extensions.DependencyInjection.Abstractions`

## Quick Start

```csharp
using Microsoft.Extensions.DependencyInjection;
using StruttonTechnologies.Core.ToolKit.Registration.Extensions;
using StruttonTechnologies.Core.ToolKit.Registration.Models;

IServiceCollection rootServices = new ServiceCollection();
IServiceCollection moduleServices = new ServiceCollection();

moduleServices.AddScoped<IMyService, MyService>();

rootServices.ComposeServicesFrom(
    moduleServices,
    new ServiceCompositionOptions
    {
        Behavior = ServiceCompositionBehavior.SkipExistingServiceType
    });
```

## Composition Behaviors

- `Append` adds all descriptors from the source collection.
- `SkipExistingServiceType` leaves existing target registrations in place.
- `ReplaceExistingServiceType` removes existing registrations for the same service type before adding the incoming descriptor.
- `ThrowIfServiceTypeExists` stops composition when the target already contains the same service type.

## Project Structure

```text
StruttonTechnologies.Core.ToolKit.Registration
├── Extensions
├── Models
├── Utilities
└── README.md
```
