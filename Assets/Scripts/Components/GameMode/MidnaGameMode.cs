// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.GameMode
{
    public delegate void OnGameModeChangedDelegate(GameObject newGameMode);

    public static class MidnaGameMode
    {
        private static GameObject _gameMode = null;
        public static event OnGameModeChangedDelegate OnGameModeChanged;

        public static GameObject CurrentGameMode
        {
            get { return _gameMode; }
            set
            {
                _gameMode = value;
                if (OnGameModeChanged != null)
                {
                    OnGameModeChanged(_gameMode);
                }
            }
        }
    }
}

