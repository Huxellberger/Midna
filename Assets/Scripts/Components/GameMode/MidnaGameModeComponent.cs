// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using Assets.Scripts.Components.Input;
using Assets.Scripts.UnityLayer.Input;
using Assets.Scripts.UnityLayer.Storage;
using UnityEngine;

namespace Assets.Scripts.Components.GameMode
{
    public class MidnaGameModeComponent : MonoBehaviour
    {
        public List<RawInput> RawInputs;

        // Use this for initialization
        private void Start ()
        {
            var inputInterface = GetComponent<IInputInterface>();
            inputInterface.SetUnityInputInterface(new DefaultUnityInput());
            inputInterface.SetInputMappingProvider(new DefaultInputMappingProvider(RawInputs, new DefaultTranslatedInputRepository( new PlayerPrefsRepository())));
        }
    }
}
