using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Interfaces.Caching
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan expiry);
    }
}
