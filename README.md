[![AppVeyor build status](https://ci.appveyor.com/api/projects/status/p1qsj8wt27023w0u/branch/master?svg=true)](https://ci.appveyor.com/project/lecaillon/preconditions/branch/master)

# Preconditions
This project is inspired by Google Guava Preconditions. 

## What is Preconditions ?
Preconditions provide convenience static methods that help to check that a method or a constructor is invoked with proper parameter or not. In other words it checks the *pre-conditions*.

Preconditions returns the tested value on success allowing to check and call a method at the same time.

On failure its methods throw an ArgumentException.
