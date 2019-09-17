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
    public class NoteToAddDtoTest
    {
        Note note = NoteMockData.GetNote().First();

        public NoteToAddDtoTest()
        {
            new NoteMaps();
        }

        [TestMethod]
        public void MapEmptyTaskToNoteDTOTest()
        {
            var noteDtoFromMap = new Note().Adapt<NoteAddDTO>();
            var noteDtoFromNew = new NoteAddDTO();

            var noteDTO1 = JsonConvert.SerializeObject(noteDtoFromMap).ToString();
            var noteDTO2 = JsonConvert.SerializeObject(noteDtoFromNew).ToString();

            Assert.AreEqual(noteDTO1, noteDTO2);
        }

        [TestMethod] public void ElementId() => Assert.AreEqual(note.Adapt<NoteAddDTO>().ElementId, 654654);
        [TestMethod] public void ElementType() => Assert.AreEqual(note.Adapt<NoteAddDTO>().ElementType, 1);
        [TestMethod] public void NoteDTOType() => Assert.AreEqual(note.Adapt<NoteAddDTO>().NoteType, 987);
        [TestMethod] public void CreatedAt() => Assert.AreEqual(note.Adapt<NoteAddDTO>().CreatedAt, 1527690442);
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteAddDTO>().CreatedAt, 0);
        [TestMethod] public void UpdatedAt() => Assert.AreEqual(note.Adapt<NoteAddDTO>().UpdatedAt, 1567519347);
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteAddDTO>().UpdatedAt, 0);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(note.Adapt<NoteAddDTO>().ResponsibleUserId, 88888);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(note.Adapt<NoteAddDTO>().CreatedBy, 2081797);
        [TestMethod] public void TextValue() => Assert.AreEqual(note.Adapt<NoteAddDTO>().Text, "Some value");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Note().Adapt<NoteAddDTO>().Text);
        [TestMethod] public void AttachmentValue() => Assert.AreEqual(note.Adapt<NoteGetDTO>().Attachment, "url of attachment");
        [TestMethod] public void AttachmentIsNull() => Assert.IsNull(new Note().Adapt<NoteGetDTO>().Attachment);

    }
}
