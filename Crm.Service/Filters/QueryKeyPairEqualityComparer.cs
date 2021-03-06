﻿using System.Collections.Generic;

namespace amocrm.library.Filters
{
    class QueryKeyPairEqualityComparer : IEqualityComparer<KeyValuePair<string, string>>
    {

        public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
        {
            return x.Key.Equals(y.Key) && x.Key.Equals(y.Key);
        }

        public int GetHashCode(KeyValuePair<string, string> obj)
        {
            return obj.GetHashCode() + obj.Value.GetHashCode();
        }
    }
}
