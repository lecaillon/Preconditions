# Preconditions.NET [![AppVeyor build status](https://ci.appveyor.com/api/projects/status/p1qsj8wt27023w0u/branch/master?svg=true)](https://ci.appveyor.com/project/lecaillon/preconditions/branch/master) [![NuGet](https://buildstats.info/nuget/Preconditions.NET)](https://www.nuget.org/packages/Preconditions.NET)
<img align="right" width="128px" height="128px" src="https://raw.githubusercontent.com/lecaillon/Preconditions/master/logo128.png">

## Introduction

Preconditions.NET provides convenience static methods to help check that a method or a constructor is invoked with proper parameter or not. In other words it checks the *pre-conditions*. The goal of this class is to improve readability of code.

Preconditions.NET returns the tested value on success, allowing to check and call a method at the same time.

On failure it **always** throws an `ArgumentException`, `ArgumentNullException` or `ArgumentOutOfRangeException`.

## Why Preconditions.NET v2 ?

Preconditions.NET version 2 is a complete rewrite that takes advantage of the new .NET 6 `CallerArgumentExpression` attribute.
It is no more mandatory to pass the parameter name being checked.
It also adds new methods (see the [checklist](/the-checklist)) and remove Check.Zero().

## How to use it ?

Because Preconditions.NET is only one code file, you can either copy the Check.cs class or include the NuGet package to your project :
```
PM> Install-Package Preconditions.NET
```

## Example

```c#
public class Employee : Person
{
    public Employee(string name, string id) : base(Check.NotNullOrEmpty(name))
    {
        Id = Check.NullableButNotEmpty(id);
    }

    public string Id { get; }
}
```

## The Checklist

- Check.NotNull(*object*)
- Check.NullableButNotEmpty (*string*)
- Check.NotNullOrEmpty(*string*)
- Check.NotNullOrEmpty(*IEnumerable*)
- Check.HasNoNulls(*IEnumerable*)
- Check.NotEmpty(*Guid*)
- Check.FileExists()
- Check.DirectoryExists()
- Check.Positive()
- Check.PositiveOrNull()
- Check.Negative()
- Check.NegativeOrNull()
- Check.NotNegative()
- Check.NotNegativeOrNull()
- Check.True(*Func<bool>*)

## Feedback and issues
Feedback, improvements, ideas are welcomed.
Feel free to create new [issues](https://github.com/lecaillon/Preconditions/issues) at the issues section.
