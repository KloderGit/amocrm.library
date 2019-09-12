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
        NoteDTO note = NoteMockData.GetNoteDTO().First();

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

        [TestMethod] public void Id() => Assert.AreEqual(note.Adapt<NoteDTO>().Id, 8663699);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(note.Adapt<NoteDTO>().ResponsibleUserId, 88888);
        [TestMethod] public void AccountId() => Assert.AreEqual(note.Adapt<NoteDTO>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(note.Adapt<NoteDTO>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(note.Adapt<NoteDTO>().CreatedBy, 2081797);
        [TestMethod] public void ElementId() => Assert.AreEqual(note.Adapt<NoteDTO>().ElementId, 654654);
        [TestMethod] public void ElementType() => Assert.AreEqual(note.Adapt<NoteDTO>().ElementType, 2);
        [TestMethod] public void NoteDTOType() => Assert.AreEqual(note.Adapt<NoteDTO>().NoteType, 987);

        [TestMethod] public void IsEditable() => Assert.AreEqual(note.Adapt<NoteDTO>().IsEditable, false);
        [TestMethod] public void IsEditableIsNull() => Assert.IsNull(new Note().Adapt<NoteDTO>().IsEditable);

        [TestMethod] public void AttachmentValue() => Assert.AreEqual(note.Adapt<NoteDTO>().Attachment, "url of attachment");
        [TestMethod] public void AttachmentIsNull() => Assert.IsNull(new Note().Adapt<NoteDTO>().Attachment);

        [TestMethod] public void TextValue() => Assert.AreEqual(note.Adapt<NoteDTO>().Text, "Some value");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Note().Adapt<NoteDTO>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(note.Adapt<NoteDTO>().CreatedAt, 1527690442);
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(note.Adapt<NoteDTO>().UpdatedAt, 1567519347);
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteDTO>().UpdatedAt, 0);

        [TestMethod] public void ParamsIsNotNull() => Assert.IsNotNull(note.Adapt<NoteDTO>().Params);
        [TestMethod] public void ParamsHasValue() => Assert.AreEqual(note.Adapt<NoteDTO>().Params.Text, "Message");
        [TestMethod] public void ParamsIsNull() => Assert.IsNull(new Note().Adapt<NoteDTO>().Params);
    }
}
