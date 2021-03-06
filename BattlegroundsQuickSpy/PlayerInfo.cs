using System;
using System.Collections.Generic;
using System.Globalization;
using HackF5.UnitySpy.HearthstoneLib;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace BattlegroundsQuickSpy
{
    public class PlayerInfo
    {
        private readonly List<PlayerInfoOverlay> _overlays;
        private GameV2 _game;
        private MindVision _mindVision;
        private DateTime lastUpdate = DateTime.Now;

        public PlayerInfo(List<PlayerInfoOverlay> overlays)
        {
            _overlays = overlays;
        }

        internal void GameStart()
        {
            _game = Hearthstone_Deck_Tracker.Core.Game;
            _mindVision = new MindVision();
            _overlays[0].Update("-3" );
            foreach (var overlay in _overlays)
            {
                overlay.Update("1");
            }
        }

        internal void ShowOverlayIfNeeded()
        {
            if (_game == null) return;

            if (_game.IsBattlegroundsMatch)
            {
                ShowOverlays();
            }
            else
            {
                HideOverlays();
            }
        }

        private void HideOverlays()
        {
            foreach (var overlay in _overlays)
            {
                overlay.Hide();
            }
        }

        private void ShowOverlays()
        {
            foreach (var overlay in _overlays)
            {
                overlay.Show();
            }
        }
        public void GameEnd()
        {
            HideOverlays();
            _game = null;
        }

        public void Update()
        {
            if ((DateTime.Now - lastUpdate).TotalSeconds < 1)
            {
                return;
            }

            if (_mindVision == null)
            {
                _overlays[0].Update("-2");
                return;
            }

            IReadOnlyList<IBattlegroundsPlayer> players;
            try
            {
                players = _mindVision.GetBattlegroundsInfo().Game.Players;
            }
            catch (Exception e)
            {
                players = new List<IBattlegroundsPlayer>();
            }
            
            foreach (var player in players)
            {
                int position = player.LeaderboardPosition - 1;
                int tier = player.TechLevel;
                
                _overlays[position].Update( $"{tier}");
            }
            lastUpdate = DateTime.Now;
        }
    }
}