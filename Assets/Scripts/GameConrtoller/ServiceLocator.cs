using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Effects;

namespace SpaceShooter.GameConrtoller
{
    public static class ServiceLocator
    {
        private static IEffectService _effectService;

        public static void Register(IEffectService service)
        {
            _effectService = service;
        }

        public static IEffectService GetEffectService()
        {
            return _effectService;
        }

        /*public static void ClearCache()
        {
            _effectService = null;
        }*/
    }
}
