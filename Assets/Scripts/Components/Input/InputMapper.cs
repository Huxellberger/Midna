// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input
{
    public class InputMapper
    {
        public PlayerInput MapInput(PlayerInput inInput)
        {
            return InputMappings[inInput];
        }

        public IDictionary<PlayerInput, PlayerInput> InputMappings { get; set; }
    }
}
