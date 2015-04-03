http://msdn.microsoft.com/en-us/data/jj554735.aspx

Package Manager Console:
Run from the FaceLessBook.Infrastruture.Data.SqlServer

1. Enable-Migrations –EnableAutomaticMigrations

Code First Migrations has two commands that you are going to become familiar with.

Add-Migration - will scaffold the next migration based on changes you have made to your model.
Update-Database - will apply any pending changes to the database.

Package Manager Console:
Run from the FaceLessBook.TestData.SqlServer
2. Set it as startup project
3. Update-Database -Verbose