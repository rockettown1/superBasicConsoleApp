using System;
using Xunit;
using utils;

namespace utils_unit_tests
{
  public class NotesUnitTests
  {
    [Fact]
    public void AddNoteWithEmptyString()
    {
      string empty = "";
      bool expected = false;
      bool actual = Notes.AddNote(empty);
      Assert.Equal(expected, actual);
    }
  }

  
}
