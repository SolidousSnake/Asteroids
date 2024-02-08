
using System;

namespace Code.Runtime.Infrastructure.Interfaces
{
    public interface IDestroyable
    {
        public event Action Destroyed;
        public void Destroy();
    }
}
