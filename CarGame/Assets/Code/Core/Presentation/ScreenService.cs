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
            Type type = screen.GetType();
            if (_screens.ContainsKey(type))
            {
                Debug.LogWarning($"Screen of type {type.Name} is already registered.");
                return;
            }

            _screens.Add(type, screen); 
        }

        public void Show<TScreen>() where TScreen : IScreen
        {
            if(_screens.TryGetValue(typeof(TScreen), out IScreen screen))
            {
                screen.Show();
            }
            else
            {
                Debug.LogWarning($"Screen of type {typeof(TScreen).Name} is not found.");
            }
        }

        public void Hide<TScreen>() where TScreen : IScreen
        {
            if(_screens.TryGetValue(typeof(TScreen), out IScreen screen))
            {
                screen.Hide();
            }
            else
            {
                Debug.LogWarning($"Screen of type {typeof(TScreen).Name} is not found.");
            }
        }
    }
}
