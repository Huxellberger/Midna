// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Components.UnityEvent;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine;
using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.States.Dead
{
    [TestFixture]
    public class DeadActionStateTestFixture {

        [Test]
        public void GetActionStateId_Dead()
        {
            var deadActionState = new DeadActionState(new ActionStateInfo());

            Assert.AreEqual(EActionStateId.Dead, deadActionState.ActionStateId);
        }

        [Test]
        public void Start_EnterDeadActionStateMessageFired()
        {
            var dispatcherComponent = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            var messageCapture = new UnityTestMessageHandleResponseObject<EnteredDeadActionStateMessage>();

            var handle = dispatcherComponent.GetUnityMessageEventDispatcher()
                .RegisterForMessageEvent<EnteredDeadActionStateMessage>(messageCapture.OnResponse);

            var deadActionState = new DeadActionState(new ActionStateInfo(dispatcherComponent.gameObject));

            deadActionState.Start();

            Assert.IsTrue(messageCapture.ActionCalled);

            dispatcherComponent.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(handle);
        }

        [Test]
        public void End_LeftDeadActionStateMessageFired()
        {
            var dispatcherComponent = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            var messageCapture = new UnityTestMessageHandleResponseObject<LeftDeadActionStateMessage>();

            var handle = dispatcherComponent.GetUnityMessageEventDispatcher()
                .RegisterForMessageEvent<LeftDeadActionStateMessage>(messageCapture.OnResponse);

            var deadActionState = new DeadActionState(new ActionStateInfo(dispatcherComponent.gameObject));

            deadActionState.Start();
            Assert.IsFalse(messageCapture.ActionCalled);

            deadActionState.End();

            Assert.IsTrue(messageCapture.ActionCalled);

            dispatcherComponent.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(handle);
        }
    }
}
