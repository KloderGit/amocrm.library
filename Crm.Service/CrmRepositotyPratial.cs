using amocrm.library.Extensions;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using Mapster;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace amocrm.library
{
    public partial class CrmRepositoty<T> : IQueryableRepository<T>, IEnumerable where T : EntityCore, new()
    {
        void isModelValid(IEnumerable<T> elements, IValidateRules<T> validator)
        {
            var result = elements.ToList().Select(x => validator.ValidateBool(x));

            if (result.Any(x => x == false)) throw new Exception("Model validation error. Check the completion of the fields.");
        }


        void isModelValidResult(IEnumerable<T> elements, IValidateRules<T> validator)
        {
            var errors = new List<ValidationResult>();

            foreach (var item in elements)
            {

            }


            var result = elements.ToList().Select(x => validator.ValidateResults(x));

            //if (result.Any(x => x == false)) throw new Exception("Model validation error. Check the completion of the fields.");
        }


        void SetUpdateDateTime(IEnumerable<T> elements)
        {
            elements.ToList().ForEach(x => x.UpdatedAt = DateTime.Now + Provider.ServerTimeDiff);
        }

        IEnumerable<T> CreateGetResult(string jsonString)
        {
            var dtoType = typeof(T).GetDtoType(ActionEnum.Get);

            var listType = typeof(List<>);
            var genericListType = listType.MakeGenericType(dtoType);

            var toJson = JObject.Parse(jsonString);
            var token = (JArray)toJson.SelectToken("_embedded").SelectToken("items");

            var result = token.ToObject(genericListType);

            return result.Adapt<List<T>>();
        }

        IEnumerable<int> CreatePostResult(string jsonString)
        {
            var listType = typeof(List<int>);

            var toJson = JObject.Parse(jsonString);
            var token = (JArray)toJson.SelectToken("_embedded").SelectToken("items");

            var result = token.Select(x => x["id"].Value<int>()).ToList();
            return result;
        }
    }
}