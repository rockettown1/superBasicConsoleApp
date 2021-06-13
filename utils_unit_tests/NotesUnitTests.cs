using System;
using Xunit;
using utils;

namespace utils_unit_tests
{
  public class NotesUnitTests
  {
    [Fact]
    public void TestAddNoteWithEmptyString()
    {
      //arrange
      string empty = "";
      bool expected = false;
      //act
      bool actual = Notes.AddNote(empty);
      //assert
      Assert.Equal(expected, actual);
    }

    // [Fact]
    // public void TestAddNote(){
    //     //arrange
    //     string myNote = "walk the dog";
    //     bool expected = true;

    // }
  }


}
