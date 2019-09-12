using amocrm.library.DTO;
using amocrm.library.Models;
using amocrm.library.Models.Fields;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Crm.Tests.Data
{
    internal class ContactMockData
    {
        public List<ContactDTO> GetDTOs()
        {
            string contactDto1 = GetJsonString();

            var toJson = JObject.Parse(contactDto1);
            var str = toJson.ToString();

            var result = toJson.ToObject(typeof(ContactDTO));

            return new List<ContactDTO> { result as ContactDTO };
        }

        public JObject GetJsonObject()
        {
            return JObject.Parse(GetJsonString());
        }


        public List<Contact> GetContacts()
        {
            var contact = new Contact()
            {
                Id = 654654,
                AccountId = 987987,
                ClosestTaskAt = new System.DateTime(2019, 10, 30),
                CreatedAt = new System.DateTime(2019, 10, 1),
                UpdatedAt = new System.DateTime(2019, 10, 2),
                CreatedBy = 55555,
                GroupId = 8888,
                Name = "TestUser1",
                ResponsibleUserId = 77777,
                UpdatedBy = 88888,
                Tags = new List<SimpleObject> { new SimpleObject { Id = 123, Name = "tag1" }, new SimpleObject { Id = 321, Name = "tag2" } },
                Leads = new List<int> { 963369, 85258, 74147 },
                Customers = new List<int> { 987654, 321654, 654963 },
                Company = new SimpleObject { Id = 95123, Name = "TestCompany" },
                Fields = new List<Field> {
                   new Field { Id = 112, Name = "Field1", IsSystem = false, Values = new List<FieldValue>{ new FieldValue { Enum = 899, Value = "FieldValue1" } } },
                   new Field { Id = 113, Name = "Field2", IsSystem = false, Values = new List<FieldValue>{ new FieldValue { Enum = 788, Value = "FieldValue2" } } },
                   new Field { Id = 114, Name = "Field3", IsSystem = false, Values = new List<FieldValue>{ new FieldValue { Enum = 788, Value = "FieldValue3" } } }
               }
            };

            return new List<Contact> { contact as Contact };
        }



        public string GetJsonString()
        {
            return @"
              {
                ""id"": 29127849,
                ""name"": ""Иджян Илья"",
                ""responsible_user_id"": 2997712,
                ""created_by"": 2997712,
                ""created_at"": 1549370109,
                ""updated_at"": 1563233551,
                ""account_id"": 17769199,
                ""updated_by"": 2997712,
                ""group_id"": 212704,
                ""company"": {
                            ""id"": 33478747,
                  ""name"": ""Название не указано"",
                  ""_links"": {
                                ""self"": {
                                    ""href"": ""/api/v2/companies?id=33478747"",
                      ""method"": ""get""
                                }
                            }
                        },
                ""leads"": {
                            ""id"": [
                              12927239,
                              16238885,
                              16239863
                  ]
                },
                ""customers"": {
                            ""id"": [
                              555555,
                              656565,
                              787878
                  ]
                },
                ""closest_task_at"": 1567630740,
                ""tags"": [
                  {
                    ""id"": 246241,
                    ""name"": ""new tag""
                  },
                  {
                    ""id"": 247981,
                    ""name"": ""Акция""
                  }
                ],
                ""custom_fields"": [
                  {
                    ""id"": 72337,
                    ""name"": ""Город"",
                    ""values"": [
                      {
                        ""value"": ""Москва""
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 571611,
                    ""name"": ""Guid"",
                    ""values"": [
                      {
                        ""value"": ""c41cb2da-8977-11e6-8102-10c37b94684b""
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 54669,
                    ""name"": ""Email"",
                    ""code"": ""EMAIL"",
                    ""values"": [
                      {
                        ""value"": ""kloder3@gmail.com"",
                        ""enum"": 114619
                      }
                    ],
                    ""is_system"": true
                  },
                  {
                    ""id"": 54665,
                    ""name"": ""Должность"",
                    ""code"": ""POSITION"",
                    ""values"": [
                      {
                        ""value"": ""разработчик""
                      }
                    ],
                    ""is_system"": true
                  },
                  {
                    ""id"": 54673,
                    ""name"": ""Мгн. сообщения"",
                    ""code"": ""IM"",
                    ""values"": [
                      {
                        ""value"": ""kloder1"",
                        ""enum"": 114625
                      }
                    ],
                    ""is_system"": true
                  },
                  {
                    ""id"": 565515,
                    ""name"": ""Дата рождения"",
                    ""values"": [
                      {
                        ""value"": ""1978-02-02 00:00:00""
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 565517,
                    ""name"": ""Образование"",
                    ""values"": [
                      {
                        ""value"": ""Высшее""
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 565519,
                    ""name"": ""Опыт занятия спортом"",
                    ""values"": [
                      {
                        ""value"": ""5 лет""
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 565521,
                    ""name"": ""№ подгруппы (по желанию)"",
                    ""values"": [
                      {
                        ""value"": ""3""
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 565525,
                    ""name"": ""Место жительства"",
                    ""values"": [
                      {
                        ""value"": ""Москва""
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 548465,
                    ""name"": ""Откуда узнал о FPA"",
                    ""values"": [
                      {
                        ""value"": ""По рекомендации"",
                        ""enum"": 1143911
                      },
                      {
                        ""value"": ""От знакомых"",
                        ""enum"": 1143913
                      }
                    ],
                    ""is_system"": false
                  },
                  {
                    ""id"": 54667,
                    ""name"": ""Телефон"",
                    ""code"": ""PHONE"",
                    ""values"": [
                      {
                        ""value"": ""79031453412"",
                        ""enum"": 114607
                      }
                    ],
                    ""is_system"": true
                  }
                ],
                ""_links"": {
                  ""self"": {
                    ""href"": ""/api/v2/contacts?id=29127849"",
                    ""method"": ""get""
                  }
                }
              }
            ";
        }
    }
}
