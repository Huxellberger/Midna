﻿// Copyright Threetee Gang (C) 2017

using System;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Test.Components.Controller;
using Assets.Scripts.Test.Components.GameMode;
using Assets.Scripts.Test.Components.Input;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.GameMode
{
    [TestFixture]
    public class MidnaGameModeComponentTestFixture
    {
        [SetUp]
        public void BeforeTest()
        {
            _inputComponent =
                TestableMonobehaviourFunctions<MockInputComponent>.PrepareMonobehaviourComponentForTest();

            _midnaGameModeComponent = _inputComponent.gameObject.AddComponent<TestMidnaGameModeComponent>();
            
            _controllerComponent = TestableMonobehaviourFunctions<TestControllerComponent>
                .PrepareMonobehaviourComponentForTest();

            _midnaGameModeComponent.PlayerControllerType = _controllerComponent.gameObject;
            _midnaGameModeComponent.PlayerCharacterType = new GameObject {name = "TestName"};
        }

        [TearDown]
        public void AfterTest()
        {
            MidnaGameMode.CurrentGameMode = null;
        }

        [Test]
        public void Creation_RegistersAsGameMode()
        {
            _midnaGameModeComponent.PrepareForTest();

            Assert.AreEqual(MidnaGameMode.CurrentGameMode, _midnaGameModeComponent.gameObject);
        }

        [Test]
        public void Creation_InputComponentSetUp()
        {
            _midnaGameModeComponent.PrepareForTest();

            Assert.NotNull(_inputComponent.InputMappingProvider);
            Assert.NotNull(_inputComponent.UnityInputInterface);
        }

        [Test]
        public void Creation_ControllerInitialisedWithPawn()
        {
            _midnaGameModeComponent.PrepareForTest();

            Assert.AreEqual(1, _midnaGameModeComponent.GetPlayerControllers().Count);

            var controller = _midnaGameModeComponent.GetPlayerControllers()[0].GetComponent<TestControllerComponent>();

            Assert.IsTrue(controller.GetPawnInstance().name.Contains(_midnaGameModeComponent.PlayerCharacterType.name));
        }

        [Test]
        public void Creation_InvalidControllerType_ThrowsException()
        {
            _midnaGameModeComponent.PlayerControllerType = new GameObject();
            Assert.Throws<ApplicationException>(() => _midnaGameModeComponent.PrepareForTest());
        }

        private TestMidnaGameModeComponent _midnaGameModeComponent;
        private MockInputComponent _inputComponent;
        private TestControllerComponent _controllerComponent;
    }
}