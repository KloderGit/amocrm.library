using amocrm.library.DTO;
using Crm.Service.Mappings;
using Crm.Service.Models;
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
    public class LeadMappingsTest
    {
        public LeadMappingsTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void LeadDtoToLead()
        {
            var leadDtoArray = LeadDtoMockData.GetLeadDTO();
            var leadArray = leadDtoArray.Adapt<IEnumerable<Lead>>();

            var lead = leadArray.First();
            var value1 = JsonConvert.SerializeObject(lead);

            var toLeadDto = leadArray.First().Adapt<LeadDTO>();

            var toLead = toLeadDto.Adapt<Lead>();
            var value2 = JsonConvert.SerializeObject(toLead);

            Assert.AreEqual(value1.ToString(), value2.ToString());
        }
        
    }
}
