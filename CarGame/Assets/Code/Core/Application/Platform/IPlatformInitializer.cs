using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Platform
{
    public interface IPlatformInitializer
    {
        bool IsInitialized { get; }
        void Initialize();  
    }
}
