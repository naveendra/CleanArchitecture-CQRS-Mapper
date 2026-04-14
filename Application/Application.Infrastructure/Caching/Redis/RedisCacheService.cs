using Application.Application.Interfaces.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Application.Infrastructure.Caching.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var data = await _cache.GetStringAsync(key);
            return data == null ? default : JsonSerializer.Deserialize<T>(data);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry
            };

            var json = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, json, options);
        }
    }
}
