using illumiyaFramework.Enums;
using illumiyaFramework.Log;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace illumiyaFramework.Caching
{
    public static class Cache
    {
        public static object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        public static bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }

        public static bool Add(string key, object value)
        {
            var memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, new CacheItemPolicy());
        }

        public static void Upsert(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(key, value, absExpiration);
        }

        public static void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }

        public static void Add(string key, Object value, EGlobal.CacheDuration duration)
        {
            var memoryCache = MemoryCache.Default;
            try
            {
                if (!string.IsNullOrEmpty(key) && value != null)
                {
                    memoryCache.Add(key, value, GetCacheDutaion(duration));
                }
            }

            catch (Exception ex)
            {
                Logger.Error("Cache Manager => Error adding item to cache", ex);
            }
        }

        private static DateTime GetCacheDutaion(EGlobal.CacheDuration duration)
        {
            switch (duration)
            {
                case EGlobal.CacheDuration.Small:
                    return DateTime.Now.AddMinutes(4);
                case EGlobal.CacheDuration.Medium:
                    return DateTime.Now.AddMinutes(30);
                case EGlobal.CacheDuration.Large:
                    return DateTime.Now.AddHours(2);
                case EGlobal.CacheDuration.ExtraLarge:
                    return DateTime.Now.AddHours(4);
                case EGlobal.CacheDuration.Huge:
                    return DateTime.Now.AddHours(12);
                default:
                    return DateTime.Now.AddMinutes(10);
            }
        }
    }
}
