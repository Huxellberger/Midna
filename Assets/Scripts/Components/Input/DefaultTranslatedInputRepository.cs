// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UnityLayer.Storage;

namespace Assets.Scripts.Components.Input
{
    public class DefaultTranslatedInputRepository 
        : ITranslatedInputRepositoryInterface
    {
        private readonly IPlayerPrefsRepositoryInterface _playerPlayerPrefsRepositoryInterface;

        public DefaultTranslatedInputRepository(IPlayerPrefsRepositoryInterface inPlayerPlayerPrefsRepositoryInterface)
        {
            _playerPlayerPrefsRepositoryInterface = inPlayerPlayerPrefsRepositoryInterface;
        }

        public IDictionary<RawInput, TranslatedInput> RetrieveMappingsForRawInputs(IEnumerable<RawInput> inRawInputs)
        {
            return inRawInputs.ToDictionary
            (
                rawInput => rawInput, rawInput => new TranslatedInput
                (
                    _playerPlayerPrefsRepositoryInterface.GetValueForKey<EInputKey>(rawInput.InputName), rawInput.InputType
                )
            );
        }
    }
}
