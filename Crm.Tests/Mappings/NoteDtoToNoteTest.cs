using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class NoteDtoToNoteTest
    {
        public NoteDtoToNoteTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void MapEmptyNoteDtoToNoteTest()
        {
            var noteFromDto = new NoteDTO().Adapt<Note>();
            var noteFromNew = new Note();

            var noteDTO1 = JsonConvert.SerializeObject(noteFromDto).ToString();
            var noteDTO2 = JsonConvert.SerializeObject(noteFromNew).ToString();

            Assert.AreEqual(noteDTO1, noteDTO2);
        }

        [TestMethod]
        public void IntToDateTest()
        {
            var note = new NoteDTO() { CreatedAt = 0 }.Adapt<Note>();
            var noteValue = new NoteDTO() { CreatedAt = 1527690442 }.Adapt<Note>();

            Assert.AreEqual(note.CreatedAt, DateTime.MinValue);
            Assert.AreEqual(noteValue.CreatedAt, new DateTime().FromTimestamp(1527690442));
        }

        [TestMethod]
        public void StringTest()
        {
            var note = new NoteDTO() { Text = null }.Adapt<Note>();
            var noteValue = new NoteDTO() { Text = "Some Name" }.Adapt<Note>();

            Assert.AreEqual(note.Text, string.Empty);
            Assert.AreEqual(noteValue.Text, "Some Name");

            var note1 = new NoteDTO() { Attachment = null }.Adapt<Note>();
            var noteValue1 = new NoteDTO() { Attachment = "Some Value" }.Adapt<Note>();

            Assert.AreEqual(note1.Attachment, null);
            Assert.AreEqual(noteValue1.Attachment, "Some Value");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var note = new NoteDTO() { Params = null }.Adapt<Note>();
            var noteValue = new NoteDTO() { Params = new ParamDTO {  Text = "Param Value" } }.Adapt<Note>();

            Assert.AreEqual(note.Params, null);
            Assert.AreNotEqual(noteValue.Params, null);
            Assert.AreEqual(noteValue.Params.Text, "Param Value");
        }
    }
}
