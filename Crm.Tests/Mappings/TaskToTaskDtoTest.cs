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
        public TaskToTaskDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void MapEmptyTaskToTaskDtoTest()
        {
            var taskDtoFromMap = new Task().Adapt<TaskDTO>();
            var taskDtoFromNew = new TaskDTO();

            var taskDTO1 = JsonConvert.SerializeObject(taskDtoFromMap).ToString();
            var taskDTO2 = JsonConvert.SerializeObject(taskDtoFromNew).ToString();

            Assert.AreEqual(taskDTO1, taskDTO2);
        }

        [TestMethod]
        public void MapFilledTaskToTaskDtoTest()
        {
            var taskFromDto = TaskMockData.GetTask().First().Adapt<TaskDTO>();

            var json = JObject.FromObject(taskFromDto);

            Assert.AreEqual(json.Count, 15);
        }

        [TestMethod]
        public void DateToIntTest()
        {
            var task = new Task() { CreatedAt = DateTime.MinValue }.Adapt<TaskDTO>();
            var taskValue = new Task() { CreatedAt = new DateTime(2019, 10, 5) }.Adapt<TaskDTO>();

            Assert.AreEqual(task.CreatedAt, 0);
            Assert.AreEqual(taskValue.CreatedAt, new DateTime(2019, 10, 5).ToTimestamp());
        }

        [TestMethod]
        public void StringTest()
        {
            var task = new Task() { Text = null }.Adapt<TaskDTO>();
            var taskValue = new Task() { Text = "Some Name" }.Adapt<TaskDTO>();

            Assert.AreEqual(task.Text, null);
            Assert.AreEqual(taskValue.Text, "Some Name");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var task = new Task() { Result = null }.Adapt<TaskDTO>();
            var taskValue = new Task() { Result = new Result { Id = 123 } }.Adapt<TaskDTO>();

            Assert.AreEqual(task.Result, null);
            Assert.AreNotEqual(taskValue.Result, null);
            Assert.AreEqual(taskValue.Result.Id, 123);
        }
    }
}
