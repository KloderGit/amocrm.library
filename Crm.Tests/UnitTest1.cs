using amocrm.library;
using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using amocrm.library.Models.Fields;
using Mapster;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {

            new ContactMaps();

            ILoggerFactory loggerFactory = new LoggerFactory().AddDebug(LogLevel.Debug);
            ILogger logger = loggerFactory.CreateLogger("TstLogger");

            var amoCrm = new CrmManager(logger, account: "apfitness", login: "kloder@fitness-pro.ru", pass: "99aad176302f7ea9213c307e1e6ab8fc");

            amoCrm.DirectAuthorization().Wait();

            var lead = new Lead
            {
                Name = "Test Lead from service2",
                PipelineId = 1020193,
                Price = 22,
                Status = 18664336,
                ResponsibleUserId = 2079718,
                Fields = new List<Field>{
                        new Field { Id = 66349, Values = new List<FieldValue> { new FieldValue { Value = 139969.ToString() } } 
                    }
                }
            };

            var leadId = amoCrm.Leads.AddAsync(lead).Result;

            lead = amoCrm.Leads.FindByIdAsync(leadId.First()).Result;

            var contact = new Contact
            {
                Name = "Test Contact from Service2",
                Fields = new List<Field> { new Field { Id = 54667, Values = new List<FieldValue> { new FieldValue { Enum = 114611, Value = "89996665544" } } } }
            };

            var contactId = amoCrm.Contacts.AddAsync(contact).Result;


            var lead2 = amoCrm.Leads.FindByIdAsync(17581201).Result;

            var contact2 = amoCrm.Contacts.FindByIdAsync(34744489).Result;

            var iii2 = amoCrm.Leads.UpdateAsync(lead).Result;


            var task = new Task
            {
                ElementId = lead.Id,
                ElementType = 2,
                CompleteTillAt = new System.DateTime(2019, 10, 5),
                TaskType = 786433,
                Text = "Test task from service",
                ResponsibleUserId = 2079718
            };

            var taskId = amoCrm.Tasks.AddAsync(task).Result;

            var note = new Note
            {
                ElementId = contactId.First(),
                ElementType = 1,
                NoteType = 4,
                Text = "Test note from service"
            };

            var noteId = amoCrm.Notes.AddAsync(note);

        }
    }
}
