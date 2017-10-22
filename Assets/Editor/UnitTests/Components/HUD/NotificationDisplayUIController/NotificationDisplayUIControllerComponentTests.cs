// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.Components.HUD.NotificationDisplayUIController;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;
using Text = UnityEngine.UI.Text;

namespace Assets.Editor.UnitTests.Components.HUD.NotificationDisplayUIController
{
    [TestFixture]
    public class NotificationDisplayUIControllerComponentTestFixture
    {
        [SetUp]
        public void BeforeTest()
        {
            _dispatcher = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            _textComponent = _dispatcher.gameObject.AddComponent<Text>();

            _controller =
                TestableMonobehaviourFunctions<TestNotificationDisplayUIControllerComponent>
                    .AddTestableMonobehaviourComponent(_dispatcher.gameObject);
        }

        [TearDown]
        public void AfterTest()
        {
            _controller = null;
            _textComponent = null;
            _dispatcher = null;
        }

        [Test]
        public void DeathMessage_SetsTextToDeathMessage()
        {
            _controller.SetMessageDispatcher(_dispatcher);

            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(_dispatcher, new EnteredDeadActionStateMessage());

            Assert.IsTrue(_textComponent.text.Equals(_controller.DeathMessage));

            _controller.SetMessageDispatcher(null);
        }

        [Test]
        public void EndDeathMessage_SetsTextToEmpty()
        {
            _controller.SetMessageDispatcher(_dispatcher);

            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(_dispatcher, new EnteredDeadActionStateMessage());
            UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(_dispatcher, new LeftDeadActionStateMessage());

            Assert.IsTrue(_textComponent.text.Equals(""));

            _controller.SetMessageDispatcher(null);
        }

        private Text _textComponent;
        private TestNotificationDisplayUIControllerComponent _controller;
        private TestUnityMessageEventDispatcherComponent _dispatcher;
    }
}

#endif
