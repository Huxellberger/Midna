// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.HUD;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.HUD
{
    public class TestHUDElementComponent
        : HUDElementComponent
            , ITestableMonobehaviour
    {
        public bool MessageInterfaceRemovedCalled { get; private set; }
        public bool MessageInterfaceSetCalled { get; private set; }

        // HUDElementComponent
        protected override void OnMessageInterfaceRemoved()
        {
            MessageInterfaceRemovedCalled = true;
        }

        protected override void OnMessageInterfaceSet()
        {
            MessageInterfaceSetCalled = true;
        }
        // ~HUDElementComponent

        // ITestableMonobehaviour
        public void PrepareForTest(params object[] parameters)
        {
            MessageInterfaceRemovedCalled = false;
            MessageInterfaceSetCalled = false;
        }
        // ~ITestableMonobehaviour
    }
}
