using System;
using Xunit;
using utils;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;


namespace utils_unit_tests
{
  public class NotesUnitTests
  {
    [Fact]
    public void TestAddNoteReturnsFalseWithEmptyString()
    {
      //arrange
      string empty = "";
      bool expected = false;
      //act
      bool actual = Notes.AddNote(empty);
      //assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAddNoteReturnsTrueWithNote()
    {
      //arrange
      string myNote = "walk the dog";
      bool expected = true;
      //act
      bool actual = Notes.AddNote(myNote);
      //assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestAddNoteToList()
    {
      Note newNote = new Note() { note = "Buy Milk" };
      List<Note> allNotes = new List<Note>();
      Notes.AddNoteToNoteList(allNotes, newNote);
      Assert.True(allNotes.Count == 1);
      Assert.Contains<Note>(newNote, allNotes);
    }

    //this will needs reworking with mocks as it's probably an integration test really
    [Fact]
    public void TestLoadNotesContainsAddedNote()
    {
      //arrange
      string testFilePath = "./bin/Debug/net5.0/myNotes.json";
      string dummyNote = "Test";
      Notes.AddNote(dummyNote);
      //act
      List<Note> allNotes = Notes.LoadNotes(testFilePath);
      string lastItem = allNotes[allNotes.Count - 1].note;
      //assert
      Assert.Contains<Note>(new Note() { note = dummyNote }, allNotes);
      Assert.Equal(lastItem, dummyNote);

    }



  }


}
