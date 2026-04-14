using Application.Application.Interfaces.Caching;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infrastructure.Caching.Memory
{
    public class MemoryCacheService : ICacheService
    {
        public Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            throw new NotImplementedException();
        }
    }
}
