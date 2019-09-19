using amocrm.library.Interfaces;
using Newtonsoft.Json.Linq;
using System;

namespace amocrm.library.Models
{
    public class EntityCore : IEntityId
    {
        public int Id { get; set; }

        public int ResponsibleUserId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = default;

        public DateTime UpdatedAt { get; set; } = default;

        public int AccountId { get; set; }

        public int GroupId { get; set; }

        public override string ToString()
        {
            return JObject.FromObject(this).ToString();
        }
    }
}
