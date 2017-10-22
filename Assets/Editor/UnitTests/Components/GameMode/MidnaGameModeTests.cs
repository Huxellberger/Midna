// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.GameMode;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.GameMode
{
    [TestFixture]
    public class MidnaGameModeTests
    {
        [SetUp]
        public void BeforeTest()
        {
            _setGameMode = null;
        }

        [TearDown]
        public void AfterTest()
        {
            _setGameMode = null;
            MidnaGameMode.CurrentGameMode = null;
        }

        [Test]
        public void SetGameMode_SetGameObjectToBeGameMode()
        {
            var gameObject = new GameObject();

            MidnaGameMode.CurrentGameMode = gameObject;

            Assert.AreSame(gameObject, MidnaGameMode.CurrentGameMode);
        }

        [Test]
        public void SetGameMode_InvokesEvent()
        {
            var gameObject = new GameObject();

            MidnaGameMode.OnGameModeChanged += OnGameModeChangedCallback;
            MidnaGameMode.CurrentGameMode = gameObject;

            MidnaGameMode.OnGameModeChanged -= OnGameModeChangedCallback;
            Assert.AreSame(gameObject, _setGameMode);
        }

        private void OnGameModeChangedCallback(GameObject newGameMode)
        {
            _setGameMode = newGameMode;
        }

        private GameObject _setGameMode;
    }
}

#endif
