## Purpose

Found the original project when search for bulk insert large data on the author blog:

[http://blog.emirosmanoski.mk/Benchmarking-Dapper-Inserts/](http://blog.emirosmanoski.mk/Benchmarking-Dapper-Inserts/)

Howerver, during my search, found that SqlBulkCopy is recomended everywhere and I am also intrested to see if Execute and Query had any difference, 
hence add two more benchmark result:

1. check if Execute and Query method has any different execution time
2. add using SqlBulkCopy

Therefore Forked the project to add the two benchmark and some more output to better see the result

## Preparation before run

Orignal github project did not say that well, but it was mention in the blog post, you will need:

1. Create a database name `ProductDapperDb` with a `Pronducts` table (sql can be found in `Commands.resx["CreateFullSchema"]`)
2. When Benchmark finish, result is saved at location: `C:\DapperBenchmarks\`, hence need create folder if not exist or change location at `Program.cs`


## Benchmark Result

1. SqlBulkCopy is the fastest method - and it is unbeliviable fast compare to other method
2. when tried 100000 times per run, the 3rd method (Table Value parameter execute) is the slowest - however, if on about 50000, it is quicker than other insert (except SqlBulkCopy - this is fastest all time)

