using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

namespace BattlegroundsQuickSpy
{
    public class BattlegroundsQuickSpyPlugin : IPlugin
    {
        private PlayerInfo _quickSpy;

        private List<PlayerInfoOverlay> _overlays;

        public void OnLoad()
        {
            CreateOverlays();
            
            _quickSpy = new PlayerInfo(_overlays);

            GameEvents.OnGameStart.Add(_quickSpy.GameStart);
            GameEvents.OnGameEnd.Add(_quickSpy.GameEnd);
            GameEvents.OnInMenu.Add(_quickSpy.InMenu);
        }
        
        public void OnUnload() {}

        public void OnButtonPress() {}

        private void CreateOverlays()
        {
            _overlays = new List<PlayerInfoOverlay>();
            for ( var i = 0; i < 8; i++ )
            {
                var overlay = new PlayerInfoOverlay();
                _overlays.Add(overlay);
                Core.OverlayCanvas.Children.Add(_overlays.Last());
                Canvas.SetTop(overlay, 180 + 93*i);
                Canvas.SetLeft(overlay, 50);
            }
        }
        
        public void OnUpdate()
        {
            _quickSpy.ShowOverlayIfNeeded();
            _quickSpy.Update();
        }

        public string Name => "Battlegrounds Quick Spy";
        public string Description =>
            "Shows important information about your opponents without hovering";

        public string ButtonText => "Settings";
        public string Author => "Kjeld Schmidt";
        public Version Version => new Version("0.0.8");
        public MenuItem MenuItem => null;
    }
}