# SqlAsFile
Use your SQL in .sql files instead of strings in C#

# Setup
* Copy the `SqlInfoGenerator.tt` to your `Data` project (where your .sql files will be created).
	* Change the namespace of line bellow to the namespace of your `Data` project.
	```csharp
		var projectNamespace = "Sample.Data";
	``` 
* Add your .sql files inside any folder os subfolder of your `Data` project.
> The `Build Action` property of the .sql files should be changed to `Embedded Resource`.
> Run the `SqlInfoGenerator.tt` (right click, `Run Custom Tool`)

# Usage
Now you can access the content of your .sql files in typed way directly from your C# code:

```
// Using the SQL inside of the file SampleSql2.sql on the folder  SampleData\Data\SampleNamespace1\SampleSubNamespace1.
var sql = SampleData.Data.SampleNamespace1.SampleSubNamespace1.Sql.SampleSql2
``` 