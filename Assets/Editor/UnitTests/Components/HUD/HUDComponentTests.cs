// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.HUD;
using Assets.Scripts.Test.Components.HUD;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.HUD
{
    [TestFixture]
    public class HUDComponentTestFixture
    {
        [Test]
        public void SetPawn_SetMessageDispatcherOnHUDElements()
        {
            var pawn = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            var hudElement = TestableMonobehaviourFunctions<TestHUDElementComponent>
                .PrepareMonobehaviourComponentForTest();

            var otherHudElement = TestableMonobehaviourFunctions<TestHUDElementComponent>
                .PrepareMonobehaviourComponentForTest();

            otherHudElement.transform.parent = hudElement.gameObject.transform;

            var hud = hudElement.gameObject.AddComponent<HUDComponent>();

            hud.SetPawn(pawn.gameObject);

            Assert.IsTrue(hudElement.MessageInterfaceSetCalled);
            Assert.IsTrue(otherHudElement.MessageInterfaceSetCalled);
        }
    }
}

#endif
