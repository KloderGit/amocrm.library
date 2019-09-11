using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Interfaces
{
    public interface IPropertyResolver
    {
        JsonProperty GetResult();
    }
}
