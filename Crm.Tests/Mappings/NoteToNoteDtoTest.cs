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
    public class NoteToNoteDtoTest
    {
        public NoteToNoteDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void MapEmptyTaskToNoteDTOTest()
        {
            var noteDtoFromMap = new Note().Adapt<NoteDTO>();
            var noteDtoFromNew = new NoteDTO();

            var noteDTO1 = JsonConvert.SerializeObject(noteDtoFromMap).ToString();
            var noteDTO2 = JsonConvert.SerializeObject(noteDtoFromNew).ToString();

            Assert.AreEqual(noteDTO1, noteDTO2);
        }

        [TestMethod]
        public void DateToIntTest()
        {
            var note = new Note() { CreatedAt = DateTime.MinValue }.Adapt<NoteDTO>();
            var noteValue = new Note() { CreatedAt = new DateTime(2019, 10, 5) }.Adapt<NoteDTO>();

            Assert.AreEqual(note.CreatedAt, 0);
            Assert.AreEqual(noteValue.CreatedAt, new DateTime(2019, 10, 5).ToTimestamp());
        }

        [TestMethod]
        public void StringTest()
        {
            var note = new Note() { Text = null }.Adapt<NoteDTO>();
            var noteValue = new Note() { Text = "Some Name" }.Adapt<NoteDTO>();

            Assert.AreEqual(note.Text, null);
            Assert.AreEqual(noteValue.Text, "Some Name");

            var note1 = new Note() { Attachment = string.Empty }.Adapt<NoteDTO>();
            var noteValue1 = new Note() { Attachment = "Some Value" }.Adapt<NoteDTO>();

            Assert.AreEqual(note1.Attachment, null);
            Assert.AreEqual(noteValue1.Attachment, "Some Value");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var note = new Note() { Params = null }.Adapt<NoteDTO>();
            var noteValue = new Note() { Params = new Params { Text = "value" } }.Adapt<NoteDTO>();

            Assert.AreEqual(note.Params, null);
            Assert.AreNotEqual(noteValue.Params, null);
            Assert.AreEqual(noteValue.Params.Text, "value");
        }
    }
}
