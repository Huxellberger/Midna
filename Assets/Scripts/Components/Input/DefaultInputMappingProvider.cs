// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input
{
    public class DefaultInputMappingProvider
        : IInputMappingProviderInterface
    {
        private readonly IEnumerable<RawInput> _rawInputs;
        private readonly IDictionary<RawInput, TranslatedInput> _inputMappings;

        public DefaultInputMappingProvider(IEnumerable<RawInput> inRawInputs, ITranslatedInputRepositoryInterface inTranslatedInputRepositoryInterface)
        {
            _rawInputs = inRawInputs;
            _inputMappings = inTranslatedInputRepositoryInterface.RetrieveMappingsForRawInputs(_rawInputs);
        }

        public IEnumerable<RawInput> GetRawInputs()
        {
            return _rawInputs;
        }

        public TranslatedInput GetTranslatedInput(RawInput inRawInput)
        {
            if (_inputMappings.ContainsKey(inRawInput))
            {
                return _inputMappings[inRawInput];
            }
            
            throw new UnassignedInputMappingException(inRawInput);
        }
    }
}
