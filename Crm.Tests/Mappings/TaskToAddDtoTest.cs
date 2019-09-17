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
    public class TaskToTaskAddDtoTest
    {
        Task task = TaskMockData.GetTask().First();

        public TaskToTaskAddDtoTest()
        {
            new TaskMaps();
        }

        [TestMethod]
        public void MapEmptyTaskDTOToTaskDTODtoTest()
        {
            var taskDtoFromMap = new Task().Adapt<TaskAddDTO>();
            var taskDtoFromNew = new TaskAddDTO();

            var taskDTO1 = JsonConvert.SerializeObject(taskDtoFromMap).ToString();
            var taskDTO2 = JsonConvert.SerializeObject(taskDtoFromNew).ToString();

            Assert.AreEqual(taskDTO1, taskDTO2);
        }


        [TestMethod] public void ElementId() => Assert.AreEqual(task.Adapt<TaskAddDTO>().ElementId, 9999);
        [TestMethod] public void ElementType() => Assert.AreEqual(task.Adapt<TaskAddDTO>().ElementType, 2);

        [TestMethod] public void CompleteTillAt() => Assert.AreEqual(task.Adapt<TaskAddDTO>().CompleteTillAt, new DateTime(2019, 10, 30).ToTimestamp());
        [TestMethod] public void CompleteTillAtZero() => Assert.AreEqual(new Task().Adapt<TaskAddDTO>().CompleteTillAt, 0);

        [TestMethod] public void TaskType() => Assert.AreEqual(task.Adapt<TaskAddDTO>().TaskType, 1);

        [TestMethod] public void TextValue() => Assert.AreEqual(task.Adapt<TaskAddDTO>().Text, "Выполненная задача");
        [TestMethod] public void TextIsNotNull() => Assert.IsNull(new Task().Adapt<TaskAddDTO>().Text);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(task.Adapt<TaskAddDTO>().CreatedAt, new DateTime(2019, 10, 5).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskAddDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(task.Adapt<TaskAddDTO>().UpdatedAt, new DateTime(2019, 10, 15).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Task().Adapt<TaskAddDTO>().UpdatedAt, 0);

        [TestMethod] public void IsEditableIsNull() => Assert.IsNull(new Task().Adapt<TaskAddDTO>().IsCompleted);

        [TestMethod] public void IsEditable() => Assert.AreEqual(task.Adapt<TaskAddDTO>().IsCompleted, true);

        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(task.Adapt<TaskAddDTO>().ResponsibleUserId, 2997712);

        [TestMethod] public void CreatedBy() => Assert.AreEqual(task.Adapt<TaskAddDTO>().CreatedBy, 2081797);
    }
}
