# Versioning

[Home](../../README.md) > [Documentation](../README.md) > Reference > Versioning

Use central package management when consuming the Core ToolKits across larger solutions.

---

## Recommended Approach

For solutions using `Directory.Packages.props`, define package versions once at the solution root.

```xml
<ItemGroup>
  <PackageVersion Include="StruttonTechnologies.Core.ToolKit.Validation" Version="1.0.0" />
  <PackageVersion Include="StruttonTechnologies.Core.ToolKit.GuardKit" Version="1.0.0" />
</ItemGroup>
```

---

## Compatibility Guidance

- Keep toolkit package versions aligned across a solution.
- Update packages intentionally.
- Avoid mixing major versions unless the package documentation confirms compatibility.

---

← Previous: [Package Reference](package-reference.md)

Back to [Documentation Home](../README.md)
