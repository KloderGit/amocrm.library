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
    public class NoteToUpdateDtoTest
    {
        Note note = NoteMockData.GetNote().First();

        public NoteToUpdateDtoTest()
        {
            new NoteMaps();
        }

        [TestMethod]
        public void MapEmptyTaskToNoteDTOTest()
        {
            var noteDtoFromMap = new Note().Adapt<NoteUpdateDTO>();
            var noteDtoFromNew = new NoteUpdateDTO();

            var noteDTO1 = JsonConvert.SerializeObject(noteDtoFromMap).ToString();
            var noteDTO2 = JsonConvert.SerializeObject(noteDtoFromNew).ToString();

            Assert.AreEqual(noteDTO1, noteDTO2);
        }

        [TestMethod] public void Id() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().Id, 8663699);
        [TestMethod] public void ElementId() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().ElementId, 654654);
        [TestMethod] public void ElementType() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().ElementType, "Contact");
        [TestMethod] public void NoteDTOType() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().NoteType, 987);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().CreatedAt, 1527690442);
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteUpdateDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().UpdatedAt, 1567519347);
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Note().Adapt<NoteUpdateDTO>().UpdatedAt, 0);

        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().ResponsibleUserId, 88888);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().CreatedBy, 2081797);
        [TestMethod] public void TextValue() => Assert.AreEqual(note.Adapt<NoteUpdateDTO>().Text, "Some value");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Note().Adapt<NoteUpdateDTO>().Text);

    }
}
