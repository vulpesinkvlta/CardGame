using Core.Platform;
using Core.Presentation;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Features
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IPlatformInitializer _platformInitializer;
        private IAuthService _authService;
        private ILoadingCurtain _loadingCurtain;

        [Inject]
        public void Construct(IPlatformInitializer platformInitializer, 
                              IAuthService authService,
                              ILoadingCurtain loadingCurtain)
        {
            _platformInitializer = platformInitializer;
            _authService = authService;
            _loadingCurtain = loadingCurtain;
        }

        public void Start()
        {
            Bootstrap();
        }

        private void Bootstrap()
        {
            _platformInitializer.Initialize();
            _authService.Authorize();

            SceneManager.LoadScene("01.Main");
            
            _loadingCurtain.Hide();
        }
    }
}
