# ExcelMapper part 2

Code sample using SQL-Server, [ExcelMapper](https://www.nuget.org/packages/ExcelMapper/5.2.590?_src=template) and [Dapper](https://www.nuget.org/packages/Dapper) to read and write data to and from Excel files.

## Why Windows Forms?

The reader may frown on Windows Forms but:

Because it is easier for the reader to simply build and run. Using a console, web or unit test are either not going to be as easy to follow.

## Why not EF Core?

EF Core works same as using Dapper but with more overhead for EF Core.

## Why not use Excel Interop?

Bad idea. It is slow and requires Excel to be installed on the machine and is not recommended for server-side applications and if version of Excel changes, it may break the application.

