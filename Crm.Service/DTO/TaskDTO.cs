﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.DTO
{
    public class TaskDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "element_type")]
        public int ElementType { get; set; }

        [JsonProperty(PropertyName = "element_id")]
        public int ElementId { get; set; }

        [JsonProperty(PropertyName = "is_completed")]
        public bool? IsCompleted { get; set; }

        [JsonProperty(PropertyName = "task_type")]
        public int TaskType { get; set; }

        [JsonProperty(PropertyName = "complete_till_at")]
        public int CompleteTillAt { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "result")]
        public TaskResultDto Result { get; set; }
    }

    public class TaskResultDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }

}
