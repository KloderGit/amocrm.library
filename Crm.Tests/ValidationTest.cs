using amocrm.library.Mappings;
using amocrm.library.Models;
using amocrm.library.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Crm.Tests
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void LeadValidations()
        {
            new LeadtMaps();

            Lead leadAddDTO = new Lead();

            try
            {
                var dtoToAdd = new DtoModelBuilder<Lead>().GetUpdateModel(new List<Lead> { leadAddDTO });
            }
            catch (Exception ex)
            {

            }
            

        }
    }
}
