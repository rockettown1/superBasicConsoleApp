using static System.Console;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace utils
{
  public class Notes
  {
    public static List<Note> notes = new List<Note>();
    static public bool AddNote(string passedNote)
    {
      if (passedNote == "")
      {
        WriteLine("You didn't use the --note option and pass a note!");
        return false;
      }
      else
      {
        LoadNotes();
        var newNote = new Note()
        {
          note = passedNote
        };
        notes.Add(newNote);
        SaveNotes();
        WriteLine($"Note added: {passedNote}");
        return true;
      }

    }

    static private List<Note> LoadNotes()
    {
      try
      {
        string jsonString = File.ReadAllText("../reminder_cli/myNotes.json");
        notes = JsonSerializer.Deserialize<List<Note>>(jsonString);
        return notes;
      }
      catch (System.Exception)
      {
        return new List<Note>();
      }

    }

    static private void SaveNotes()
    {
      string jsonString = JsonSerializer.Serialize(notes);
      string fileName = "myNotes.json";
      File.WriteAllText(fileName, jsonString);
    }

    static public void ListNotes()
    {
      LoadNotes();
      for (int i = 0; i < notes.Count; i++)
      {
        WriteLine($"{i + 1}: {notes[i].note}");
      }
    }

    static public void RemoveNote(int noteNum)
    {
      LoadNotes();
      WriteLine($"Removing the note: {notes[noteNum - 1].note}");
      notes.RemoveAt(noteNum - 1);
      SaveNotes();
    }


  }
}
