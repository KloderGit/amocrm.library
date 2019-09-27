using amocrm.library.Configurations;
using amocrm.library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ModelTests
{
    [TestClass]
    public class EntityMemberFieldsTest
    {
        [TestMethod]
        public void GetNullFieldTest()
        {
            var entity = new EntityMember();
            entity.Fields.Add( new Field {
                Id = 555,
                Values = new List<FieldValue> {
                    new FieldValue { Enum = 444, Value = "value"}
                }
            });

            var result = entity.GetField(0);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetFieldTest()
        {
            var entity = new EntityMember();
            entity.Fields.Add(new Field
            {
                Id = 555,
                Values = new List<FieldValue> {
                    new FieldValue { Enum = 444, Value = "value"}
                }
            });

            var result = entity.GetField(555);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Values[0].Value, "value");
        }

        [TestMethod]
        public void SetFieldTest()
        {
            var entity = new EntityMember();
            entity.SetField(fieldId: 555, value: "value");

            var result = entity.Fields.Find(x => x.Id == 555).Values[0].Value;

            Assert.AreEqual(result, "value");
        }

        [TestMethod]
        public void SetFieldAndTypeTest()
        {
            var entity = new EntityMember();
            entity.SetField(fieldId: 555, value: "value", 888);

            var value = entity.Fields.Find(x => x.Id == 555).Values[0].Value;
            var @enum = entity.Fields.Find(x => x.Id == 555).Values[0].Enum;

            Assert.AreEqual(value, "value");
            Assert.AreEqual(@enum, 888);
        }

        [TestMethod]
        public void SetAndGetFieldAndTypeTest()
        {
            var entity = new EntityMember();
            entity.SetField(fieldId: 555, value: "value", 888);

            var result = entity.GetField(555);

            Assert.IsInstanceOfType(result, typeof(Field));
            Assert.AreEqual(result.Id, 555);
            Assert.AreEqual(result.Values.Count, 1);
            Assert.AreEqual(result.Values[0].Enum, 888);
            Assert.AreEqual(result.Values[0].Value, "value");
        }
    }
}
