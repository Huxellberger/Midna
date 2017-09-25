// Copyright Threetee Gang (C) 2017

using System;

namespace Assets.Scripts.Components.Input
{
    public class InvalidInputHandlerException : Exception
    {
        public InvalidInputHandlerException(InputHandler inInputHandler)
            : base("Could not find an input mapped to" + inInputHandler)
        {
        }
    }
}
