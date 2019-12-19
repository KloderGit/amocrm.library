using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Crm.Tests.Data;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class TaskToTaskUpdateDtoTest
    {
        Task task = TaskMockData.GetTask().First();

        public TaskToTaskUpdateDtoTest()
        {
            new TaskMaps();
        }

        [TestMethod]
        public void MapEmptyTaskDTOToTaskDTODtoTest()
        {
            var taskDtoFromMap = new Task().Adapt<TaskUpdateDTO>();
            var taskDtoFromNew = new TaskUpdateDTO();

            var taskDTO1 = JsonConvert.SerializeObject(taskDtoFromMap).ToString();
            var taskDTO2 = JsonConvert.SerializeObject(taskDtoFromNew).ToString();

            Assert.AreEqual(taskDTO1, taskDTO2);
        }

        [TestMethod] public void Id() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().Id, 5555);
        [TestMethod] public void ElementId() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().ElementId, 9999);
        [TestMethod] public void ElementType() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().ElementType, "lead");

        [TestMethod] public void CompleteTillAt() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().CompleteTillAt, new DateTime(2019, 10, 30).ToTimestamp());
        [TestMethod] public void CompleteTillAtZero() => Assert.AreEqual(new Task().Adapt<TaskUpdateDTO>().CompleteTillAt, 0);

        [TestMethod] public void TaskType() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().TaskType, 1);

        [TestMethod] public void TextValue() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().Text, "Выполненная задача");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Task().Adapt<TaskUpdateDTO>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().CreatedAt, new DateTime(2019, 10, 5).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskUpdateDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().UpdatedAt, new DateTime(2019, 10, 15).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskUpdateDTO>().UpdatedAt, 0);

        [TestMethod] public void IsCompleted() => Assert.IsNull(new Task().Adapt<TaskUpdateDTO>().IsCompleted);
        [TestMethod] public void IsCompletedValue() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().IsCompleted, true);

        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().ResponsibleUserId, 2997712);

        [TestMethod] public void CreatedBy() => Assert.AreEqual(task.Adapt<TaskUpdateDTO>().CreatedBy, 2081797);
    }
}
