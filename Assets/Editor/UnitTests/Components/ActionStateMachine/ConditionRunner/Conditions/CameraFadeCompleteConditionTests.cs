// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Components.UnityEvent;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine.ConditionRunner.Conditions;
using Assets.Scripts.Components.Camera;
using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.UnityEvent;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.ConditionRunner.Conditions
{
    [TestFixture]
    public class CameraFadeCompleteConditionTestFixture
    {
        private TestUnityMessageEventDispatcherComponent _dispatcher;
        private CameraFadeCompleteCondition _condition;

        private static float ExpectedDelay = 3.0f;
        private static float ExpectedAlpha = 0.2f;

        [SetUp]
        public void BeforeTest()
        {
            _dispatcher = TestableMonobehaviourFunctions<TestUnityMessageEventDispatcherComponent>
                .PrepareMonobehaviourComponentForTest();

            _condition = new CameraFadeCompleteCondition(ExpectedAlpha, ExpectedDelay, _dispatcher);
        }

        [TearDown]
        public void AfterTest()
        {
            _condition = null;
            _dispatcher = null;
        }

        [Test]
        public void Start_FiresCameraFadeEvent()
        {
            var eventCapture = new UnityTestMessageHandleResponseObject<FadeCameraMessage>();
            var handle = UnityMessageEventFunctions.RegisterActionWithDispatcher<FadeCameraMessage>(_dispatcher, eventCapture.OnResponse);
            _condition.Start();

            Assert.IsTrue(eventCapture.ActionCalled);
            Assert.AreEqual(ExpectedAlpha, eventCapture.MessagePayload.FadeAlpha);
            Assert.AreEqual(ExpectedDelay, eventCapture.MessagePayload.FadeDelay);

            UnityMessageEventFunctions.UnregisterActionWithDispatcher(_dispatcher, handle);
            _condition.End();
        }

        [Test]
        public void Update_FadeTimeNotPassed_DoesNotComplete()
        {
            _condition.Start();
            _condition.Update(ExpectedDelay * 0.5f);

            Assert.IsFalse(_condition.Complete);
            _condition.End();
        }

        [Test]
        public void Update_FadeTimePassed_Completes()
        {
            _condition.Start();
            _condition.Update(ExpectedDelay + 0.1f);

            Assert.IsTrue(_condition.Complete);
            _condition.End();
        }
    }
}
