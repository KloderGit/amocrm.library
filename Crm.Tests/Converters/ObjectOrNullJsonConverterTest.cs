using amocrm.library.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crm.Tests.Converters
{
    [TestClass]
    public class ObjectOrNullJsonConverterTest
    {
        [TestMethod]
        public void ReadJsonFieldWithValue()
        {
            var jsonString = @"{""company"": {
                                    ""id"": 33478747,
                                    ""name"": ""Название не указано""
                               } }";

            var contact = JsonConvert.DeserializeObject<ContactGetDTO>(jsonString);

            Assert.AreNotEqual(contact.Company, null);
            Assert.AreEqual(contact.Company.Id, 33478747);
        }

        [TestMethod]
        public void ReadJsonFieldWithOutValue()
        {
            var jsonString = @"{""company"": {} }";

            var contact = JsonConvert.DeserializeObject<ContactGetDTO>(jsonString);

            Assert.AreEqual(contact.Company, null);
        }

        [TestMethod]
        public void WriteJsonFieldWithValue()
        {
            var leadDto = new LeadGetDTO { MainContact = new SimpleDtoObject { Id = 123 } };

            var jsonObject = JObject.FromObject(leadDto);

            Assert.AreEqual(jsonObject.ContainsKey("main_contact"), true);
            Assert.AreEqual(jsonObject["main_contact"].HasValues, true);
            Assert.AreEqual(jsonObject["main_contact"]["id"], 123);
        }

        [TestMethod]
        public void WriteJsonFieldWithOutValue()
        {
            var leadDto = new LeadGetDTO();

            var jsonObject = JObject.FromObject(leadDto);

            Assert.AreEqual(jsonObject.ContainsKey("main_contact"), true);
            Assert.AreEqual(jsonObject["main_contact"].HasValues, false);
        }
    }
}
