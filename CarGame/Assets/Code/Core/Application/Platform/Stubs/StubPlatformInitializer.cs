
using UnityEngine;

namespace Core.Platform
{
    public class StubPlatformInitializer : IPlatformInitializer
    {
        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            IsInitialized = true;
            Debug.Log("[StubPlatformInitializer] Platform inititalized");
        }
    }
}
