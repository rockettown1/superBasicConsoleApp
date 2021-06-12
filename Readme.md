## A super basic CLI todo app example for beginners to C#.

Uses dotnet 5  
Contains a console app and a classlib.  
  
Note: Uses the experimental System.CommandLine package (DragonFruit app model) to use commandline arguments as seperate variables rather than the normal string array (version 0.3.0-alpha.21216.1)
  
Serialises a List of notes and stores them in a local json file.
Reads from the local json file and deserialises back into C#.
  
**commands**
* dotnet run add --note "whatever your note is"
* dotnet run list
* dotnet run remove



