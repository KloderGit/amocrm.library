using Crm.Domain;
using Crm.Service.DTO;
using Crm.Service.Mappings;
using Crm.Tests.Data;
using JsonDiffPatchDotNet;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class ContactMappingsTest
    {
        [TestMethod]
        public void ContactMap1()
        {
            new ContactMaps();

            var contactsDto = new JsonMockDataContact().GetDTOs();
            var contacts = contactsDto.Adapt<IEnumerable<Contact>>();

            var cont1 = contacts.First();
            cont1.Name = "New Name";
            var value1 = JsonConvert.SerializeObject(cont1);

            var cont2 = contacts.Adapt<IEnumerable<ContactDTO>>().Adapt<IEnumerable<Contact>>().First();
            var value2 = JsonConvert.SerializeObject(cont2);


            var jdp = new JsonDiffPatch();
            var output = jdp.Diff(value1, value2);

            var dddd = jdp.Unpatch(value2, output);


            var dddd3 = jdp.Unpatch(value1, output);

            Assert.AreEqual(value1.ToString(), value2.ToString());
        }
    }
}
