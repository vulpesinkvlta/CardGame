using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Presentation
{
    public class ScreenService : IScreenService
    {
        private readonly Dictionary<Type, IScreen> _screens = new();

        public void Register(IScreen screen)
        {
            if (screen == null)
            {
                Debug.LogError("[ScreenService] Cannot register null screen.");
                return;
            }

            Type type = screen.GetType();

            if (_screens.ContainsKey(type))
            {
                Debug.LogWarning($"[ScreenService] Screen already registered: {type.Name}");
                return;
            }

            _screens.Add(type, screen);
        }

        public void Show<TScreen>() where TScreen : IScreen
        {
            Type type = typeof(TScreen);

            if (_screens.TryGetValue(type, out IScreen screen))
            {
                screen.Show();
                return;
            }

            Debug.LogError($"[ScreenService] Screen not found: {type.Name}");
        }

        public void Hide<TScreen>() where TScreen : IScreen
        {
            Type type = typeof(TScreen);

            if (_screens.TryGetValue(type, out IScreen screen))
            {
                screen.Hide();
                return;
            }

            Debug.LogError($"[ScreenService] Screen not found: {type.Name}");
        }

        public void HideAll()
        {
            foreach (IScreen screen in _screens.Values)
            {
                screen.Hide();
            }
        }

        public void ShowOnly<TScreen>() where TScreen : IScreen
        {
            HideAll();
            Show<TScreen>();
        }
    }
}
