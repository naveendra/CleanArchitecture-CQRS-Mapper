using Application.Application.Interfaces.Caching;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infrastructure.Caching.Hybrid
{
    public class HybridCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICacheService _redisCache;

        public HybridCacheService(IMemoryCache memoryCache, ICacheService redisCache)
        {
            _memoryCache = memoryCache;
            _redisCache = redisCache;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            // 🟢 L1 - Memory
            if (_memoryCache.TryGetValue(key, out T value))
            {
                return value;
            }

            // 🔴 L2 - Redis
            var redisValue = await _redisCache.GetAsync<T>(key);

            if (redisValue != null)
            {
                _memoryCache.Set(key, redisValue, TimeSpan.FromMinutes(5));
                return redisValue;
            }

            return default;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            // Set both
            _memoryCache.Set(key, value, expiry);
            await _redisCache.SetAsync(key, value, expiry);
        }
    }
}
