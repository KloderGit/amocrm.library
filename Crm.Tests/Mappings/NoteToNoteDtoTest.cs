using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Crm.Tests.Data;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class NoteToNoteDtoTest
    {
        NoteGetDTO note = NoteMockData.GetNoteDTO().First();

        public NoteToNoteDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void MapEmptyTaskToNoteDTOTest()
        {
            var noteDtoFromMap = new Note().Adapt<NoteGetDTO>();
            var noteDtoFromNew = new NoteGetDTO();

            var noteDTO1 = JsonConvert.SerializeObject(noteDtoFromMap).ToString();
            var noteDTO2 = JsonConvert.SerializeObject(noteDtoFromNew).ToString();

            Assert.AreEqual(noteDTO1, noteDTO2);
        }

        [TestMethod] public void Id() => Assert.AreEqual(note.Adapt<NoteGetDTO>().Id, 8663699);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(note.Adapt<NoteGetDTO>().ResponsibleUserId, 88888);
        [TestMethod] public void AccountId() => Assert.AreEqual(note.Adapt<NoteGetDTO>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(note.Adapt<NoteGetDTO>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(note.Adapt<NoteGetDTO>().CreatedBy, 2081797);
        [TestMethod] public void ElementId() => Assert.AreEqual(note.Adapt<NoteGetDTO>().ElementId, 654654);
        [TestMethod] public void ElementType() => Assert.AreEqual(note.Adapt<NoteGetDTO>().ElementType, 2);
        [TestMethod] public void NoteDTOType() => Assert.AreEqual(note.Adapt<NoteGetDTO>().NoteType, 987);

        [TestMethod] public void IsEditable() => Assert.AreEqual(note.Adapt<NoteGetDTO>().IsEditable, false);
        [TestMethod] public void IsEditableIsNull() => Assert.IsNull(new Note().Adapt<NoteGetDTO>().IsEditable);

        [TestMethod] public void AttachmentValue() => Assert.AreEqual(note.Adapt<NoteGetDTO>().Attachment, "url of attachment");
        [TestMethod] public void AttachmentIsNull() => Assert.IsNull(new Note().Adapt<NoteGetDTO>().Attachment);

        [TestMethod] public void TextValue() => Assert.AreEqual(note.Adapt<NoteGetDTO>().Text, "Some value");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Note().Adapt<NoteGetDTO>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(note.Adapt<NoteGetDTO>().CreatedAt, 1527690442);
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteGetDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(note.Adapt<NoteGetDTO>().UpdatedAt, 1567519347);
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteGetDTO>().UpdatedAt, 0);

        [TestMethod] public void ParamsIsNotNull() => Assert.IsNotNull(note.Adapt<NoteGetDTO>().Params);
        [TestMethod] public void ParamsHasValue() => Assert.AreEqual(note.Adapt<NoteGetDTO>().Params.Text, "Message");
        [TestMethod] public void ParamsIsNull() => Assert.IsNull(new Note().Adapt<NoteGetDTO>().Params);
    }
}
