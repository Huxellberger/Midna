// Copyright Threetee Gang (C) 2017

using System;

namespace Assets.Scripts.Components.Input
{
    public class UnassignedInputMappingException : Exception
    {
        public UnassignedInputMappingException(RawInput unassignedInput)
            : base("Could not find an input mapped to" + unassignedInput.InputName)
        {
        }
    }
}
