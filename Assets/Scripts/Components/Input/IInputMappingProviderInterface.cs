// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input
{
    public interface IInputMappingProviderInterface
    {
        IEnumerable<RawInput> GetRawInputs();
        TranslatedInput GetTranslatedInput(RawInput inRawInput);
    }
}
