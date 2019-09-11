using amocrm.library.DTO;
using amocrm.library.Models;
using System;
using System.Collections.Generic;

namespace Crm.Tests.Data
{
    public static class TaskMockData
    {
        public static IEnumerable<TaskDTO> GetTaskDto()
        {
            var dto1 = new TaskDTO
            {
                Id = 5555,
                AccountId = 17769199,
                CompleteTillAt = 1567630740,
                CreatedAt = 1527690442,
                CreatedBy = 2081797,
                GroupId = 212704,
                Duration = 55,
                ElementId = 9999,
                ElementType = 2,
                IsCompleted = true,
                ResponsibleUserId = 2997712,
                TaskType = 1,
                Text = "Выполненная задача",
                UpdatedAt = 1567519347,
                Result = new TaskResultDto { Id = 888, Text = "К выполнению" }
            };

            return new List<TaskDTO> { dto1 };
        }

        public static IEnumerable<Task> GetTask()
        {
            var task = new Task
            {
                Id = 5555,
                AccountId = 17769199,
                CompleteTillAt = new DateTime(2019, 10, 30),
                CreatedAt = new DateTime(2019, 10, 5),
                CreatedBy = 2081797,
                GroupId = 212704,
                Duration = 55,
                ElementId = 9999,
                ElementType = 2,
                IsCompleted = true,
                ResponsibleUserId = 2997712,
                TaskType = 1,
                Text = "Выполненная задача",
                UpdatedAt = new DateTime(2019, 10, 15),
                Result = new Result { Id = 888, Text = "К выполнению" }
            };

            return new List<Task> { task };
        }
    }
}
