// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input
{
    public interface ITranslatedInputRepositoryInterface
    {
        IDictionary<RawInput, TranslatedInput> RetrieveMappingsForRawInputs(IEnumerable<RawInput> inRawInputs);
    }
}
