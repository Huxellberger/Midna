// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.Input
{
    public interface IInputBinderInterface
    {
        void SetInputInterface(IInputInterface inInputInterface);
        void RegisterInputHandler(InputHandler inInputHandler);
        void UnregisterInputHandler(InputHandler inInputHandler);
    }
}
