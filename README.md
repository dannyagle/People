# People
Easily generate random people first and last names.  Useful for populating demo data with fictional people with real names.

The names comes from old census files.  I made lists of the top 1000 male names, female names, and family names and turned 
them into json files for files easy consumption.  My code currently ignores the frequency value found in the census data.

Recently updated to .NET Standard 2.0.

## ConsoleApplication
The console application is a simple way to see the People code in action.  It's not meant to show how to use the code, but does offer a stopwatch to show how well the Parallel works when getting large numbers of people.

## Service Fabric Examples
These examples require that the Service Fabric SDK be installed and running on your system.
