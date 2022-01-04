# Preconditions [![AppVeyor build status](https://ci.appveyor.com/api/projects/status/p1qsj8wt27023w0u/branch/master?svg=true)](https://ci.appveyor.com/project/lecaillon/preconditions/branch/master) [![NuGet](https://buildstats.info/nuget/Preconditions.NET)](https://www.nuget.org/packages/Preconditions.NET)

## What is Preconditions.NET ?

Preconditions provides convenience static methods to help check that a method or a constructor is invoked with proper parameter or not. In other words it checks the *pre-conditions*. The goal of this class is to improve readability of code.

Preconditions returns the tested value on success, allowing to check and call a method at the same time.

On failure it **always** throws an `ArgumentException`, `ArgumentNullException` or `ArgumentOutOfRangeException`.

## What is Preconditions.NET V2 ?

Preconditions.NET version 2 is a complete rewrite that takes advantage of the new .NET 6 `CallerArgumentExpression` attribute.
It is no more mandatory to pass the parameter name being checked.
It also adds new methods (see the checklist) and remove Check.Zero().

## How to use it ?

Because Preconditions is only one code file, you can either copy paste the Check.cs class or include the Nuget package to your project :
https://www.nuget.org/packages/Preconditions.NET
```
PM> Install-Package Preconditions.NET
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

## Feedback and issues
Feedback, improvements, ideas are welcomed.
Feel free to create new [issues](https://github.com/lecaillon/Preconditions/issues) at the issues section.
