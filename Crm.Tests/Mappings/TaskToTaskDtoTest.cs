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
            new ContactMaps();
        }

        [TestMethod]
        public void MapEmptyTaskDTOToTaskDTODtoTest()
        {
            var taskDtoFromMap = new Task().Adapt<TaskDTO>();
            var taskDtoFromNew = new TaskDTO();

            var taskDTO1 = JsonConvert.SerializeObject(taskDtoFromMap).ToString();
            var taskDTO2 = JsonConvert.SerializeObject(taskDtoFromNew).ToString();

            Assert.AreEqual(taskDTO1, taskDTO2);
        }


        [TestMethod] public void Id() => Assert.AreEqual(task.Adapt<TaskDTO>().Id, 5555);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(task.Adapt<TaskDTO>().ResponsibleUserId, 2997712);
        [TestMethod] public void AccountId() => Assert.AreEqual(task.Adapt<TaskDTO>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(task.Adapt<TaskDTO>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(task.Adapt<TaskDTO>().CreatedBy, 2081797);
        [TestMethod] public void ElementId() => Assert.AreEqual(task.Adapt<TaskDTO>().ElementId, 9999);
        [TestMethod] public void ElementType() => Assert.AreEqual(task.Adapt<TaskDTO>().ElementType, 2);
        [TestMethod] public void TaskType() => Assert.AreEqual(task.Adapt<TaskDTO>().TaskType, 1);
        [TestMethod] public void IsEditable() => Assert.AreEqual(task.Adapt<TaskDTO>().IsCompleted, true);
        [TestMethod] public void IsEditableIsNull() => Assert.IsNull(new Task().Adapt<TaskDTO>().IsCompleted);
        [TestMethod] public void Duration() => Assert.AreEqual(task.Adapt<TaskDTO>().Duration, 55);

        [TestMethod] public void TextValue() => Assert.AreEqual(task.Adapt<TaskDTO>().Text, "Выполненная задача");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Task().Adapt<TaskDTO>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(task.Adapt<TaskDTO>().CreatedAt, new DateTime(2019, 10, 5).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(task.Adapt<TaskDTO>().UpdatedAt, new DateTime(2019, 10, 15).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskDTO>().UpdatedAt, 0);

        [TestMethod] public void CompleteTillAt() => Assert.AreEqual(task.Adapt<TaskDTO>().CompleteTillAt, new DateTime(2019, 10, 30).ToTimestamp());
        [TestMethod] public void CompleteTillAtZero() => Assert.AreEqual(new Task().Adapt<TaskDTO>().CompleteTillAt, 0);

        [TestMethod] public void ResultIsNotNull() => Assert.IsNotNull(task.Adapt<TaskDTO>().Result);
        [TestMethod] public void ResultHasValue() => Assert.AreEqual(task.Adapt<TaskDTO>().Result.Id, 888);
        [TestMethod] public void ResultIsNull() => Assert.IsNull(new Task().Adapt<TaskDTO>().Result);

    }
}
