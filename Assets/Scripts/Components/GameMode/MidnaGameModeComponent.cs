﻿// Copyright Threetee Gang (C) 2017

using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components.Controller;
using Assets.Scripts.Components.Input;
using Assets.Scripts.UnityLayer.Input;
using Assets.Scripts.UnityLayer.Storage;
using UnityEngine;

namespace Assets.Scripts.Components.GameMode
{
    public class MidnaGameModeComponent : MonoBehaviour
    {
        public GameObject PlayerControllerType;
        public GameObject PlayerCharacterType;

        private List<GameObject> PlayerControllers { get; set; }

        private void Awake ()
        {
            MidnaGameMode.CurrentGameMode = gameObject;

            InitialiseInput();
            InitialisePlayer();
        }

        private void InitialiseInput()
        {
            var rawInputs = InputManagerParser.ReadInputManagerOutput();

            if (rawInputs == null || !rawInputs.Any())
            {
                // Temporarily grab raw inputs from default translation
                rawInputs = DefaultTranslatedInputRepository.GetDefaultMappings().Select(defaultInput => defaultInput.Key).ToList();
            }

            var inputInterface = GetComponent<IInputInterface>();
            inputInterface.SetUnityInputInterface(new DefaultUnityInput());
            inputInterface.SetInputMappingProvider(new DefaultInputMappingProvider(rawInputs, new DefaultTranslatedInputRepository(new PlayerPrefsRepository())));
        }

        private void InitialisePlayer()
        {
            PlayerControllers = new List<GameObject>();

            var playerController = Instantiate(PlayerControllerType);
            var controllerComponent = playerController.GetComponent<ControllerComponent>();

            if (controllerComponent == null)
            {
                throw new ApplicationException("Controller type was not valid! Needs a controller component!");
            }

            controllerComponent.CreatePawnOfType(PlayerCharacterType);

            PlayerControllers.Add(playerController);
        }
    }
}
