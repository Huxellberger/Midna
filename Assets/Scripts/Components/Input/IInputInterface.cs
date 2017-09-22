// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.Input
{
    public interface IInputInterface
    {
        void PushInputBinder(InputBinder inInputBinding);

        void PopInputBinder(InputBinder inInputBinder);
    }
}
