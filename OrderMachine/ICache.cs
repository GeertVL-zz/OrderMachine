using System;

namespace OrderMachine
{
    public interface ICache
    {
        T Retrieve<T>(string key, Func<T> readThrough);
    }
}