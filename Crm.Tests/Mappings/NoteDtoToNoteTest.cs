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
    public class NoteDtoToNoteTest
    {
        NoteDTO dto = NoteMockData.GetNoteDTO().First();

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

        [TestMethod] public void Id() => Assert.AreEqual(dto.Adapt<Note>().Id, 8663699);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(dto.Adapt<Note>().ResponsibleUserId, 88888);
        [TestMethod] public void AccountId() => Assert.AreEqual(dto.Adapt<Note>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(dto.Adapt<Note>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(dto.Adapt<Note>().CreatedBy, 2081797);
        [TestMethod] public void ElementId() => Assert.AreEqual(dto.Adapt<Note>().ElementId, 654654);
        [TestMethod] public void ElementType() => Assert.AreEqual(dto.Adapt<Note>().ElementType, 2);
        [TestMethod] public void NoteType() => Assert.AreEqual(dto.Adapt<Note>().NoteType, 987);

        [TestMethod] public void IsEditable() => Assert.AreEqual(dto.Adapt<Note>().IsEditable, false);
        [TestMethod] public void IsEditableIsNull() => Assert.IsNull(new NoteDTO().Adapt<Note>().IsEditable);

        [TestMethod] public void AttachmentValue() => Assert.AreEqual(dto.Adapt<Note>().Attachment, "url of attachment");
        [TestMethod] public void AttachmentIsNull() => Assert.IsNull(new NoteDTO().Adapt<Note>().Attachment);

        [TestMethod] public void TextValue() => Assert.AreEqual(dto.Adapt<Note>().Text, "Some value");
        [TestMethod] public void TextIsEmpty() => Assert.AreEqual(new NoteDTO().Adapt<Note>().Text, string.Empty);
        [TestMethod] public void TextIsNotNull() => Assert.IsNotNull(new NoteDTO().Adapt<Note>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(dto.Adapt<Note>().CreatedAt, new DateTime().FromTimestamp(1527690442));
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new NoteDTO().Adapt<Note>().CreatedAt, DateTime.MinValue);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(dto.Adapt<Note>().UpdatedAt, new DateTime().FromTimestamp(1567519347));
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new NoteDTO().Adapt<Note>().UpdatedAt, DateTime.MinValue);

        [TestMethod] public void ParamsIsNotNull() => Assert.IsNotNull(dto.Adapt<Note>().Params);
        [TestMethod] public void ParamsHasValue() => Assert.AreEqual(dto.Adapt<Note>().Params.Text, "Message");
        [TestMethod] public void ParamsIsNull() => Assert.IsNull(new NoteDTO().Adapt<Note>().Params);
    }
}
