using amocrm.library.Converters;
using amocrm.library.DTO;
using Crm.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Tests.Converters
{
    [TestClass]
    public class PostJsonSerializerSettingsTest
    {
        IEnumerable<LeadGetDTO> array = LeadMockData.GetLeadDTO();

        [TestMethod]
        public void CommonJsonSettingEmptyTest()
        {
            // Statement - Only one property will appear in JSON

            var dto = new LeadGetDTO { Id = 123 };

            var jObject = JObject.FromObject(dto, new PostJsonSerializerSettings().GetSerializer());

            Assert.AreEqual(jObject.Count, 1);
        }

        [TestMethod]
        public void CommonJsonSettingFullTest()
        {
            // All properties are included in json

            var propertiesCountFirst = JObject.FromObject(array.First()).Count;
            var propertiesCountSecond = JObject.FromObject(array.First(), new PostJsonSerializerSettings().GetSerializer()).Count;

            Assert.AreEqual(propertiesCountFirst, propertiesCountSecond);
        }


        // This settings only work for properties that already has value / it skips values inserted after JsonConverter

        [TestMethod]
        public void NullReferenceSetting()
        {
            // Statement - objects with a value of null are discarded from json

            var dto = array.First();
            dto.Company = null;
            dto.Tags = null;

            var jObj = JObject.FromObject(dto, new PostJsonSerializerSettings().GetSerializer());

            var companyProperty = jObj.ContainsKey("company");
            var tagsProperty = jObj.ContainsKey("tags");

            Assert.AreEqual(jObj.Count, 19);
            Assert.AreEqual(companyProperty, false);
            Assert.AreEqual(tagsProperty, false);
        }

        [TestMethod]
        public void ExcludeZeroIntJsonProperty()
        {
            // Statement - Properties with a value of zero are discarded from json

            var dto = new LeadGetDTO { Id = 0 };

            var jObject = JObject.FromObject(dto, new PostJsonSerializerSettings().GetSerializer());

            Assert.AreEqual(jObject.ContainsKey("id"), false);
        }
    }


}
