using utils;
using static System.Console;

namespace reminder_cli
{
  class Program
  {
    //This is using the experimental DragonFruit model to parse commandline args directly into the main function.
    //Notes in the command line use the --note option and the actual text for the note should be wrapped in quotes.
    ///<param name="note">A note to store or remove</param>
    ///<param name="args">The standard arguments array</param>
    static void Main(string note, string[] args)
    {
      try
      {
        var command = args[0].ToLower();
        if (command == "add")
        {
          Notes.AddNote(note);
        }
        else if (command == "list")
        {
          Notes.ListNotes();
        }
        else if (command == "remove")
        {
          int noteNum;
          WriteLine("Which note would you like to remove? Please enter a number:");
          Notes.ListNotes();
          string reply = ReadLine();
          if (int.TryParse(reply, out noteNum))
          {
            Notes.RemoveNote(noteNum);
          }
          else
          {
            WriteLine("You didn't enter a number for the note");
          }
        }
        else
        {
          WriteLine("Command not found");
        }

      }
      catch (System.Exception)
      {
        WriteLine("You didn't enter any commands!");
      }
    }
  }
}
