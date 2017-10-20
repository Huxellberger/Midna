// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Core;
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

            var inputTranslations = new Dictionary<RawInput, TranslatedInput>();

            foreach (var rawInput in inRawInputs)
            {
                var potentialEnum =
                    EnumExtensions.TryParse<EInputKey>(
                        _playerPlayerPrefsRepositoryInterface.GetValueForKey(rawInput.InputName));

                if (potentialEnum.IsSet())
                {
                    inputTranslations.Add(rawInput, new TranslatedInput(potentialEnum.Get(), rawInput.InputType));
                }
                else
                {
                    return DefaultMappings;
                }
            }

            return inputTranslations;
        }

        private bool MappingsAreNotCustomised(IEnumerable<RawInput> inRawInputs)
        {
            return inRawInputs.Any(rawInput => _playerPlayerPrefsRepositoryInterface.GetValueForKey(rawInput.InputName) == null);
        }

        // These are the fallback mappings, you should change these if you update the InputManager
        public static Dictionary<RawInput, TranslatedInput> GetDefaultMappings()
        {
            return new Dictionary<RawInput, TranslatedInput>(new RawInputEqualityComparer())
            {
                {
                    new RawInput("Vertical_Analog", EInputType.Analog),
                    new TranslatedInput(EInputKey.VerticalAnalog, EInputType.Analog)
                },
                {
                    new RawInput("Horizontal_Analog", EInputType.Analog),
                    new TranslatedInput(EInputKey.HorizontalAnalog, EInputType.Analog)
                },
                {
                    new RawInput("Enter_Button", EInputType.Button),
                    new TranslatedInput(EInputKey.SelectButton, EInputType.Button)
                },
                {
                    new RawInput("LeftShift_Button", EInputType.Button),
                    new TranslatedInput(EInputKey.SprintButton, EInputType.Button)
                },
                {
                    new RawInput("Mouse0_Button", EInputType.Button),
                    new TranslatedInput(EInputKey.UsePrimaryEquipment, EInputType.Button)
                },
                {
                    new RawInput("Mouse1_Button", EInputType.Button),
                    new TranslatedInput(EInputKey.UseSecondaryEquipment, EInputType.Button)
                },

            };
        }
    }
}
