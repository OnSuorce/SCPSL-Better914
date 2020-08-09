using System;
using Exiled.API.Features;

namespace Better914
{
    class Better914 : Plugin<Config>
    {
        private static readonly Lazy<Better914> LazyInstance = new Lazy<Better914>(() => new Better914());
        public static Better914 pluginInstance => LazyInstance.Value;
        private Handlers._914Event _914Event;

        public override void OnEnabled()
        {

            Register();
        }
        public override void OnDisabled()
        {
            UnRegister();
        }
        public void Register()
        {
            _914Event = new Handlers._914Event();
            Exiled.Events.Handlers.Scp914.UpgradingItems += _914Event.OnUpgrading;
            Exiled.Events.Handlers.Player.Died += _914Event.OnPlayerDead;

        }
        public void UnRegister()
        {
            Exiled.Events.Handlers.Scp914.UpgradingItems -= _914Event.OnUpgrading;
            Exiled.Events.Handlers.Player.Died -= _914Event.OnPlayerDead;

            _914Event = null;
        }




    }
}
