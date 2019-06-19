using MagGestion.DataServices.Interface;
using System;
using System.Runtime.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.DataServices
{
    public class InMemoryCache : ICacheService
    {
        public T Get<T>(string cacheKey) where T : class
        {
            return MemoryCache.Default.Get(cacheKey) as T;
        }

        public void Set(string cacheKey, object item)
        {
            if (item != null)
            {
                MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(30));
            }
        }
    }
}
