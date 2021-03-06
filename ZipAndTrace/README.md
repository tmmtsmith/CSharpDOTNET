Zip Delete, Then Trace Move and Import
============
This project will delete all zip files (holding zip data), then move the trace files to the appropriate location for input into a database.

Note that compared to a few other methods, this process runs 54% faster overall then other methods.  One gig of data requires approximately 9 minutes.

To run this program:
  1.  Create a new C# console application program.
  2.  Copy and paste the code into the application (from `traceimport.cs`).
  3.  Add the necessary assemblies based on the references in this application (see the **using** at top of `traceimport.cs`).
  4.  Create your TEMP and MAIN tables in SQL Server (only TEMP provided in `temp.sql`, as you should customize MAIN to what you need).
  5.  Adjust the stp_InsertTraceData stored procedure (from `inserttracedata.sql`) to capture the data you want.
  6.  Run the program.
