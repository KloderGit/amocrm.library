# amocrm.library

Библиотека доступа к AmoCrm.
Получение\Добаление\Обновление Контактов, Компаний, Сделок, Примечаний, Задач. Информация о CustomFields.
Переподключается при истечении cookies доступа.

Пэт проект, код ревью не проходила.

nuget - Install-Package amocrm.library.net -Version 0.2.6.1

Примеры

var crm = new CrmManager(account: "xxx", login: "xxx", pass: "xxx");

с логером Microsoft.Extensions.Logging.ILogger
var crm = new CrmManager(logger: logger, account: "xxx", login: "xxx", pass: "xxx");

Запрос по ID
Lead lead = await crm.Leads.FindByIdAsync(id);

Запрос с фильтром
List<Contact> contacts = await crm.Contacts.Where(p => p.Contains == "Иванов").ToList()
List<Lead> leads = amoCrm.Leads.Where(x=>x.Status == 18664336).ToList();

Создать
IEnumerable<int> result = await crm.Tasks.AddAsync(task);
int id = result.FirstOrDefault();

IEnumerable<int> result = await crm.Notes.AddAsync(notes);

Значения custom fields
CustomFieldInfo fields = await crm.CustomFields;
Dictionary<int, string> seminars = fields.Lead[66349].Enums;

Ошибки
AmoCrmHttpException (Коды ошибок - https://www.amocrm.ru/developers/content/api/errors)
AmoCrmModelException
