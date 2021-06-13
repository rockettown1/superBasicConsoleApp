using static System.Console;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace utils
{
  public class Notes
  {

    static public bool AddNote(string passedNote)
    {
      if (passedNote == "")
      {
        WriteLine("You didn't use the --note option and pass a note!");
        return false;
      }
      else
      {
        List<Note> notes = LoadNotes();
        var newNote = new Note()
        {
          note = passedNote
        };
        notes.Add(newNote);
        SaveNotes(notes);
        WriteLine($"Note added: {passedNote}");
        return true;
      }

    }

    static private List<Note> LoadNotes()
    {
      try
      {
        string jsonString = File.ReadAllText("../reminder_cli/myNotes.json");
        List<Note> notes = JsonSerializer.Deserialize<List<Note>>(jsonString);
        return notes;
      }
      catch (System.Exception)
      {
        return new List<Note>();
      }

    }

    static private void SaveNotes(List<Note> myList)
    {
      string jsonString = JsonSerializer.Serialize(myList);
      string fileName = "myNotes.json";
      File.WriteAllText(fileName, jsonString);
    }

    static public void ListNotes()
    {
      List<Note> notes = LoadNotes();
      for (int i = 0; i < notes.Count; i++)
      {
        WriteLine($"{i + 1}: {notes[i].note}");
      }
    }

    static public void RemoveNote(int noteNum)
    {
      if (noteNum > LoadNotes().Count || noteNum < 0)
      {
        WriteLine("Number does not exist in the list");
      }
      else
      {
        List<Note> notes = LoadNotes();
        WriteLine($"Removing the note: {notes[noteNum - 1].note}");
        notes.RemoveAt(noteNum - 1);
        SaveNotes(notes);
      }

    }


  }
}
