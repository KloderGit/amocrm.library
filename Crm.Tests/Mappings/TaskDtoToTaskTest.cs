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
        public TaskDtoToTaskTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void MapEmptyTaskDtoToTaskTest()
        {
            var taskFromDto = new TaskDTO().Adapt<Task>();
            var taskFromNew = new Task();

            var taskDTO1 = JsonConvert.SerializeObject(taskFromDto).ToString();
            var taskDTO2 = JsonConvert.SerializeObject(taskFromNew).ToString();

            Assert.AreEqual(taskDTO1, taskDTO2);
        }

        [TestMethod]
        public void MapFilledTaskDtoToTaskTest()
        {
            var taskFromDto = TaskMockData.GetTaskDto().First().Adapt<Task>();

            var json = JObject.FromObject(taskFromDto);

            Assert.AreEqual(json.Count, 15);
        }

        [TestMethod]
        public void IntToDateTest()
        {
            var task = new TaskDTO() { CreatedAt = 0 }.Adapt<Task>();
            var taskValue = new TaskDTO() { CreatedAt = 1527690442 }.Adapt<Task>();

            Assert.AreEqual(task.CreatedAt, DateTime.MinValue);
            Assert.AreEqual(taskValue.CreatedAt, new DateTime().FromTimestamp(1527690442));
        }

        [TestMethod]
        public void StringTest()
        {
            var task = new TaskDTO() { Text = null }.Adapt<Task>();
            var taskValue = new TaskDTO() { Text = "Some Name" }.Adapt<Task>();

            Assert.AreEqual(task.Text, string.Empty);
            Assert.AreEqual(taskValue.Text, "Some Name");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var task = new TaskDTO() { Result = null }.Adapt<Task>();
            var taskValue = new TaskDTO() { Result = new TaskResultDto { Id = 123 } }.Adapt<Task>();

            Assert.AreEqual(task.Result, null);
            Assert.AreNotEqual(taskValue.Result, null);
            Assert.AreEqual(taskValue.Result.Id, 123);
        }
    }
}
