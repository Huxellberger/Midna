// Copyright Threetee Gang (C) 2017

using System.Linq;
using Assets.Scripts.Components.Input;
using Assets.Scripts.UnityLayer.Input;
using Assets.Scripts.UnityLayer.Storage;
using UnityEngine;

namespace Assets.Scripts.Components.GameMode
{
    public class MidnaGameModeComponent : MonoBehaviour
    {
        private void Awake ()
        {
            MidnaGameMode.CurrentGameMode = gameObject;

            var rawInputs = InputManagerParser.ReadInputManagerOutput();

            if (rawInputs == null || !rawInputs.Any())
            {
                // Temporarily grab raw inputs from default translation
                rawInputs = DefaultTranslatedInputRepository.GetDefaultMappings().Select(defaultInput => defaultInput.Key).ToList();
            }
            
            var inputInterface = GetComponent<IInputInterface>();
            inputInterface.SetUnityInputInterface(new DefaultUnityInput());
            inputInterface.SetInputMappingProvider(new DefaultInputMappingProvider(rawInputs, new DefaultTranslatedInputRepository( new PlayerPrefsRepository())));
        }
    }
}
