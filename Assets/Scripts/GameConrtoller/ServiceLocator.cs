using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Effects;
using SpaceShooter.Audio;
using System;

namespace SpaceShooter.GameConrtoller
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            _services[typeof(T)] = service;
        }

        public static T Get<T>()
        {
            if (_services.TryGetValue(typeof(T), out var service))
                return (T)service;

            Debug.LogError($"ServiceLocator: service {typeof(T)} not registered");
            return default;
        }

        /*public static void ClearCache()
        {
            _effectService = null;
        }*/
    }
}
