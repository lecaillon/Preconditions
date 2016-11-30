# Preconditions [![AppVeyor build status](https://ci.appveyor.com/api/projects/status/p1qsj8wt27023w0u/branch/master?svg=true)](https://ci.appveyor.com/project/lecaillon/preconditions/branch/master)
This project is inspired by Google Guava Preconditions. 

## What is Preconditions ?
Preconditions provide convenience static methods that help to check that a method or a constructor is invoked with proper parameter or not. In other words it checks the *pre-conditions*. The goal of this class is to improve readability of code.

Preconditions returns the tested value on success allowing to check and call a method at the same time.

On failure its methods throw an ArgumentException.

## How to use it ?

Because Preconditions is only one code file, you can either copy paste the Check.cs class or include the Nuget package to your project :
https://www.nuget.org/packages/Preconditions.NET

## Example

```c#
public class Employee : Person
{
    public string Id { get; }

    public Employee(string name, string id) : base(Check.NotNullOrEmpty(name, nameof(name)))
    {
        Id = Check.NullableButNotEmpty(id, nameof(id));
    }
}
```
