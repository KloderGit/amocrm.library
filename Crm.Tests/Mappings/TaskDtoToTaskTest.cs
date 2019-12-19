using amocrm.library.Configurations;
using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Crm.Tests.Data;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class TaskDtoToTaskTest
    {
        TaskGetDTO dto = TaskMockData.GetTaskDto().First();

        public TaskDtoToTaskTest()
        {
            new TaskMaps();
        }

        [TestMethod]
        public void MapEmptyTaskDtoToTaskTest()
        {
            var taskFromDto = new TaskGetDTO().Adapt<Task>();
            var taskFromNew = new Task();

            var taskDTO1 = JsonConvert.SerializeObject(taskFromDto).ToString();
            var taskDTO2 = JsonConvert.SerializeObject(taskFromNew).ToString();

            Assert.AreEqual(taskDTO1, taskDTO2);
        }


        [TestMethod] public void Id() => Assert.AreEqual(dto.Adapt<Task>().Id, 5555);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(dto.Adapt<Task>().ResponsibleUserId, 2997712);
        [TestMethod] public void AccountId() => Assert.AreEqual(dto.Adapt<Task>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(dto.Adapt<Task>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(dto.Adapt<Task>().CreatedBy, 2081797);
        [TestMethod] public void ElementId() => Assert.AreEqual(dto.Adapt<Task>().ElementId, 9999);
        [TestMethod] public void ElementType() => Assert.AreEqual(dto.Adapt<Task>().ElementType, ElementTypeEnum.lead);
        [TestMethod] public void TaskType() => Assert.AreEqual(dto.Adapt<Task>().TaskType, 1);
        [TestMethod] public void IsEditable() => Assert.AreEqual(dto.Adapt<Task>().IsCompleted, true);
        [TestMethod] public void IsEditableIsNull() => Assert.IsNull(new TaskGetDTO().Adapt<Task>().IsCompleted);
        [TestMethod] public void Duration() => Assert.AreEqual(dto.Adapt<Task>().Duration, 55);

        [TestMethod] public void TextValue() => Assert.AreEqual(dto.Adapt<Task>().Text, "Выполненная задача");
        [TestMethod] public void TextIsEmpty() => Assert.AreEqual(new TaskGetDTO().Adapt<Task>().Text, string.Empty);
        [TestMethod] public void TextIsNotNull() => Assert.IsNotNull(new TaskGetDTO().Adapt<Task>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(dto.Adapt<Task>().CreatedAt, new DateTime().FromTimestamp(1527690442));
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new TaskGetDTO().Adapt<Task>().CreatedAt, DateTime.MinValue);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(dto.Adapt<Task>().UpdatedAt, new DateTime().FromTimestamp(1567519347));
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new TaskGetDTO().Adapt<Task>().UpdatedAt, DateTime.MinValue);

        [TestMethod] public void CompleteTillAt() => Assert.AreEqual(dto.Adapt<Task>().CompleteTillAt, new DateTime().FromTimestamp(1567630740));
        [TestMethod] public void CompleteTillAtZero() => Assert.AreEqual(new TaskGetDTO().Adapt<Task>().CompleteTillAt, DateTime.MinValue);

        [TestMethod] public void ResultIsNotNull() => Assert.IsNotNull(dto.Adapt<Task>().Result);
        [TestMethod] public void ResultHasValue() => Assert.AreEqual(dto.Adapt<Task>().Result.Id, 888);
        [TestMethod] public void ResultIsNull() => Assert.IsNull(new TaskGetDTO().Adapt<Task>().Result);

    }
}
