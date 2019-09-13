using amocrm.library.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Crm.Tests.Converters
{
    [TestClass]
    public class ObjectOrArrayJsonConverterTest
    {
        [TestMethod]
        public void ReadJsonFieldWithValue()
        {
            var jsonString = @"{ ""tags"": [
                                    {
                                        ""id"": 246241,
                                        ""name"": ""new tag""
                                    },
                                    {
                                        ""id"": 247981,
                                        ""name"": ""Акция""
                                    }
                                ]}";

            var contact = JsonConvert.DeserializeObject<ContactGetDTO>(jsonString);

            Assert.AreNotEqual(contact.Tags, null);
            Assert.AreEqual(contact.Tags.Count, 2);
        }

        [TestMethod]
        public void ReadJsonFieldWithOutValue()
        {
            var jsonString = @"{""tags"": {} }";

            var contact = JsonConvert.DeserializeObject<ContactGetDTO>(jsonString);

            Assert.AreEqual(contact.Tags, null);
        }

        [TestMethod]
        public void WriteJsonFieldWithValue()
        {
            var leadDto = new LeadGetDTO { Tags = new List<SimpleDtoObject> { new SimpleDtoObject { Id = 123 }, new SimpleDtoObject { Id = 654 } } };

            var jsonObject = JObject.FromObject(leadDto);

            Assert.AreEqual(jsonObject.ContainsKey("tags"), true);
            Assert.AreEqual(((JArray)jsonObject["tags"]).Count, 2);
        }

        [TestMethod]
        public void WriteJsonFieldWithOutValue()
        {
            var leadDto = new LeadGetDTO();

            var jsonObject = JObject.FromObject(leadDto);

            Assert.AreEqual(jsonObject.ContainsKey("tags"), true);
            Assert.AreEqual(jsonObject["tags"].HasValues, false);
        }
    }
}
