using Core.Application;
using System;

namespace Core.Infrastructure
{
    public class SystemRandomService : IRandomService
    {
        private readonly Random _random;

        public SystemRandomService()
        {
            _random = new Random();
        }

        public int Range(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
