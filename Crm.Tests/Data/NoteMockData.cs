using amocrm.library.Configurations;
using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Models;
using System.Collections.Generic;

namespace Crm.Tests.Data
{
    internal static class NoteMockData
    {
        public static IEnumerable<NoteGetDTO> GetNoteDTO()
        {
            var dto1 = new NoteGetDTO
            {
                Id = 8663699,
                AccountId = 17769199,
                CreatedAt = 1527690442,
                CreatedBy = 2081797,
                GroupId = 212704,
                ElementId = 654654,
                ElementType = 2,
                IsEditable = false,
                NoteType = 987,
                ResponsibleUserId = 88888,
                UpdatedAt = 1567519347,
                Params = new ParamDTO { Text = "Message", Service = "SourceService" },
                Text = "Some value",
                Attachment = "url of attachment"
            };

            return new List<NoteGetDTO> { dto1 };
        }

        public static IEnumerable<Note> GetNote()
        {
            var note = new Note
            {
                Id = 8663699,
                AccountId = 17769199,
                CreatedAt = new System.DateTime().FromTimestamp(1527690442),
                CreatedBy = 2081797,
                GroupId = 212704,
                ElementId = 654654,
                ElementType = ElementTypeEnum.contact,
                IsEditable = false,
                NoteType = 987,
                ResponsibleUserId = 88888,
                UpdatedAt = new System.DateTime().FromTimestamp(1567519347),
                Params = new Params{ Text = "Message", Service = "SourceService" },
                Text = "Some value",
                Attachment = "url of attachment"
            };

            return new List<Note> { note };
        }
    }
}
