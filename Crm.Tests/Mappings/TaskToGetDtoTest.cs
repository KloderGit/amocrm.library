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
    public class TaskToTaskDtoTest
    {
        Task task = TaskMockData.GetTask().First();

        public TaskToTaskDtoTest()
        {
            new TaskMaps();
        }

        [TestMethod]
        public void MapEmptyTaskDTOToTaskDTODtoTest()
        {
            var taskDtoFromMap = new Task().Adapt<TaskGetDTO>();
            var taskDtoFromNew = new TaskGetDTO();

            var taskDTO1 = JsonConvert.SerializeObject(taskDtoFromMap).ToString();
            var taskDTO2 = JsonConvert.SerializeObject(taskDtoFromNew).ToString();

            Assert.AreEqual(taskDTO1, taskDTO2);
        }


        [TestMethod] public void Id() => Assert.AreEqual(task.Adapt<TaskGetDTO>().Id, 5555);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(task.Adapt<TaskGetDTO>().ResponsibleUserId, 2997712);
        [TestMethod] public void AccountId() => Assert.AreEqual(task.Adapt<TaskGetDTO>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(task.Adapt<TaskGetDTO>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(task.Adapt<TaskGetDTO>().CreatedBy, 2081797);
        [TestMethod] public void ElementId() => Assert.AreEqual(task.Adapt<TaskGetDTO>().ElementId, 9999);
        [TestMethod] public void ElementType() => Assert.AreEqual(task.Adapt<TaskGetDTO>().ElementType, 2);
        [TestMethod] public void TaskType() => Assert.AreEqual(task.Adapt<TaskGetDTO>().TaskType, 1);
        [TestMethod] public void IsEditable() => Assert.AreEqual(task.Adapt<TaskGetDTO>().IsCompleted, true);
        [TestMethod] public void IsEditableIsNull() => Assert.IsNull(new Task().Adapt<TaskGetDTO>().IsCompleted);
        [TestMethod] public void Duration() => Assert.AreEqual(task.Adapt<TaskGetDTO>().Duration, 55);

        [TestMethod] public void TextValue() => Assert.AreEqual(task.Adapt<TaskGetDTO>().Text, "Выполненная задача");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Task().Adapt<TaskGetDTO>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(task.Adapt<TaskGetDTO>().CreatedAt, new DateTime(2019, 10, 5).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskGetDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(task.Adapt<TaskGetDTO>().UpdatedAt, new DateTime(2019, 10, 15).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskGetDTO>().UpdatedAt, 0);

        [TestMethod] public void CompleteTillAt() => Assert.AreEqual(task.Adapt<TaskGetDTO>().CompleteTillAt, new DateTime(2019, 10, 30).ToTimestamp());
        [TestMethod] public void CompleteTillAtZero() => Assert.AreEqual(new Task().Adapt<TaskGetDTO>().CompleteTillAt, 0);

        [TestMethod] public void ResultIsNotNull() => Assert.IsNotNull(task.Adapt<TaskGetDTO>().Result);
        [TestMethod] public void ResultHasValue() => Assert.AreEqual(task.Adapt<TaskGetDTO>().Result.Id, 888);
        [TestMethod] public void ResultIsNull() => Assert.IsNull(new Task().Adapt<TaskGetDTO>().Result);

    }
}
