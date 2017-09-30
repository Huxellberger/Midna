// Copyright Threetee Gang (C) 2017

using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UnityLayer.Storage;

namespace Assets.Scripts.Components.Input
{
    public class DefaultTranslatedInputRepository 
        : ITranslatedInputRepositoryInterface
    {
        public readonly Dictionary<RawInput, TranslatedInput> DefaultMappings;
        private readonly IPlayerPrefsRepositoryInterface _playerPlayerPrefsRepositoryInterface;

        public DefaultTranslatedInputRepository(IPlayerPrefsRepositoryInterface inPlayerPlayerPrefsRepositoryInterface)
        {
            _playerPlayerPrefsRepositoryInterface = inPlayerPlayerPrefsRepositoryInterface;

            DefaultMappings = GetDefaultMappings();
        }

        public IDictionary<RawInput, TranslatedInput> RetrieveMappingsForRawInputs(IEnumerable<RawInput> inRawInputs)
        {
            // Multiple enumerations is fine, will usually fail on first if not saved and this is easier to follow
            if (inRawInputs == null || !inRawInputs.Any() || MappingsAreNotCustomised(inRawInputs))
            {
                return DefaultMappings;
            }

            return inRawInputs.ToDictionary
            (
                rawInput => rawInput, rawInput => new TranslatedInput
                (
                    (EInputKey)Enum.Parse(typeof(EInputKey), _playerPlayerPrefsRepositoryInterface.GetValueForKey(rawInput.InputName)), rawInput.InputType
                )
            );
        }

        private bool MappingsAreNotCustomised(IEnumerable<RawInput> inRawInputs)
        {
            return inRawInputs.Any(rawInput => _playerPlayerPrefsRepositoryInterface.GetValueForKey(rawInput.InputName) == null);
        }

        // These are the fallback mappings, you should change these if you update the InputManager
        private static Dictionary<RawInput, TranslatedInput> GetDefaultMappings()
        {
            return new Dictionary<RawInput, TranslatedInput>
            {
                { new RawInput("Vertical_Analog", EInputType.Analog), new TranslatedInput(EInputKey.VerticalAnalog, EInputType.Analog)  },
                { new RawInput("Horizontal_Analog", EInputType.Analog), new TranslatedInput(EInputKey.HorizontalAnalog, EInputType.Analog)  }
            };
        }
    }
}
