// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input
{
    public class InputMapper
    {
        public TranslatedInput MapInput(RawInput inInput)
        {
            return InputMappings[inInput];
        }

        public IDictionary<RawInput, TranslatedInput> InputMappings { get; set; }
    }
}
