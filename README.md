# Core Capability Tool Kits

The **Core Capability Tool Kits** solution contains foundational utilities and shared components used across Strutton Technologies core capability libraries.

These toolkits are intentionally separated into their own solution to avoid dependency cycles and to allow foundational components to evolve independently from higher-level modules such as Identity, Domain services, or Application orchestration layers.

---

## Purpose

Toolkits provide **small, focused building blocks** that can be used by nearly any project type including:

- Domain libraries
- Application services
- Identity systems
- Infrastructure layers
- Web applications
- Console tools
- Background services

They are intentionally lightweight and dependency-minimal.

---

## Design Principles

### Focused Responsibility

Each toolkit should provide functionality in a clearly defined area.

Examples include:

- Guards
- Extensions
- Helpers
- Value utilities

---

### Minimal Dependencies

Toolkits should depend only on:

- .NET base libraries
- other toolkit libraries when necessary

They should **not depend on higher level modules**.

---

### Reusable Across All Layers

Toolkits must remain usable from:

- Domain
- Application
- Infrastructure
- API
- UI

---

### No Business Logic

Toolkits should not contain application-specific or domain-specific logic.

They exist only to provide **general purpose functionality**.

---

## Why Toolkits Are a Separate Solution

The Core Capability Tool Kits are intentionally placed in a **separate solution** from other core libraries.

This avoids the classic dependency problem:

Toolkit → Identity → CoreCapabilities → Toolkit

Separating the solutions allows toolkit libraries to be compiled, versioned, and published independently.

Higher level modules may depend on the toolkits, but toolkits never depend on higher level modules.

---

## Current Toolkit Projects

Project | Purpose
--- | ---
Guards | Fluent guard evaluation and continuation behaviors

---

## Guards Toolkit

The **Guards toolkit** provides a fluent pattern for defensive evaluation and continuation behavior.

Example:

    return await Guard.IsNull(user)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

Or when evaluating object properties safely:

    return await Guard.IsNullOrWhiteSpace(user, u => u.Email)
        .ReturnEmptyArray(u => _userManager.GetLoginsAsync(u));

This pattern allows developers to clearly express:

Evaluate → Decide → Continue

without writing repetitive defensive code.

---

## Future Toolkits

Additional toolkits may be added over time as reusable patterns emerge.

Examples may include:

- Extensions
- Result utilities
- Functional helpers
- Validation helpers
- Mapping utilities

Each toolkit will remain small, focused, and independently versioned.

---

## Relationship to Core Capability Libraries

The toolkit libraries support higher level packages such as:

- CoreCapabilities
- Identity
- Application orchestration modules

Toolkits provide the **lowest level shared utilities** used across these packages.

---

## Summary

The **Core Capability Tool Kits** solution provides a collection of foundational utilities designed to:

- reduce repetitive code
- improve readability
- maintain architectural separation
- avoid circular dependencies
- support reuse across the entire platform
