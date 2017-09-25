// Copyright Threetee Gang (C) 2017

using System;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.Input;
using Assets.Scripts.Test.Components.Input;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.Input
{
    public class InputBinderTestInputHandler
        : InputHandler
    {
        public InputBinderTestInputHandler(EInputHandlerResult inInputHandlerResult)
            :base()
        {
            ButtonResponses.Add
            (
                InputKeyToUse, pressed =>
                {
                    ReceivedResponse = true;
                    return inInputHandlerResult;
                }
            );

            AnalogResponses.Add
            (
                InputKeyToUse, analogValue =>
                {
                    ReceivedResponse = true;
                    return inInputHandlerResult;
                }
            );

            MouseResponses.Add
            (
                InputKeyToUse, mousePosition =>
                {
                    ReceivedResponse = true;
                    return inInputHandlerResult;
                }
            );
        }

        public bool ReceivedResponse { get; set; }
        public static readonly EInputKey InputKeyToUse = EInputKey.FireButton;
    };

    [TestFixture]
    public class InputBinderComponentTests
    {

        [SetUp]
        public void SetupTest()
        {
            _inputBinderComponent = TestableMonobehaviourFunctions<TestInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();
            _inputInterface = new MockInputInterface();
        }

        [TearDown]
        public void TearDown()
        {
            _inputInterface = null;
            _inputBinderComponent = null;
        }

        [Test]
        public void ReceiveButtonEvent_ExectutesUntilResponseHandled()
        {
            var firstHandler = new InputBinderTestInputHandler(EInputHandlerResult.Unhandled);
            var secondHandler = new InputBinderTestInputHandler(EInputHandlerResult.Handled);
            var thirdHandler = new InputBinderTestInputHandler(EInputHandlerResult.Handled);

            _inputBinderComponent.RegisterInputHandler(firstHandler);
            _inputBinderComponent.RegisterInputHandler(secondHandler);
            _inputBinderComponent.RegisterInputHandler(thirdHandler);

            _inputBinderComponent.SetInputInterface(_inputInterface);

            _inputInterface.TestActivateButtonEvent(InputBinderTestInputHandler.InputKeyToUse, false);

            Assert.IsTrue(firstHandler.ReceivedResponse);
            Assert.IsTrue(secondHandler.ReceivedResponse);
            Assert.IsFalse(thirdHandler.ReceivedResponse);
        }

        [Test]
        public void ReceiveAnalogEvent_ExectutesUntilResponseHandled()
        {
            var firstHandler = new InputBinderTestInputHandler(EInputHandlerResult.Unhandled);
            var secondHandler = new InputBinderTestInputHandler(EInputHandlerResult.Handled);
            var thirdHandler = new InputBinderTestInputHandler(EInputHandlerResult.Handled);

            _inputBinderComponent.RegisterInputHandler(firstHandler);
            _inputBinderComponent.RegisterInputHandler(secondHandler);
            _inputBinderComponent.RegisterInputHandler(thirdHandler);

            _inputBinderComponent.SetInputInterface(_inputInterface);

            _inputInterface.TestActivateAnalogEvent(InputBinderTestInputHandler.InputKeyToUse, 0.0f);

            Assert.IsTrue(firstHandler.ReceivedResponse);
            Assert.IsTrue(secondHandler.ReceivedResponse);
            Assert.IsFalse(thirdHandler.ReceivedResponse);
        }

        [Test]
        public void ReceiveMouseEvent_ExectutesUntilResponseHandled()
        {
            var firstHandler = new InputBinderTestInputHandler(EInputHandlerResult.Unhandled);
            var secondHandler = new InputBinderTestInputHandler(EInputHandlerResult.Handled);
            var thirdHandler = new InputBinderTestInputHandler(EInputHandlerResult.Handled);

            _inputBinderComponent.RegisterInputHandler(firstHandler);
            _inputBinderComponent.RegisterInputHandler(secondHandler);
            _inputBinderComponent.RegisterInputHandler(thirdHandler);

            _inputBinderComponent.SetInputInterface(_inputInterface);

            _inputInterface.TestActivateMouseEvent(InputBinderTestInputHandler.InputKeyToUse, new Vector3());

            Assert.IsTrue(firstHandler.ReceivedResponse);
            Assert.IsTrue(secondHandler.ReceivedResponse);
            Assert.IsFalse(thirdHandler.ReceivedResponse);
        }

        [Test]
        public void UnregisterHandler_DoesNotReceiveResponse()
        {
            var handler = new InputBinderTestInputHandler(EInputHandlerResult.Handled);

            _inputBinderComponent.RegisterInputHandler(handler);

            _inputBinderComponent.SetInputInterface(_inputInterface);

            _inputBinderComponent.UnregisterInputHandler(handler);

            _inputInterface.TestActivateMouseEvent(InputBinderTestInputHandler.InputKeyToUse, new Vector3());

            Assert.IsFalse(handler.ReceivedResponse);
        }

        [Test]
        public void SetNullInputInterface_ThrowsException()
        {
            IInputInterface inputInterface = null;
            Assert.Throws<ArgumentNullException>(() => _inputBinderComponent.SetInputInterface(inputInterface));
        }

        [Test]
        public void UnregisterHandlerNotRegistered_ThrowsException()
        {
            Assert.Throws<InvalidInputHandlerException>(() =>_inputBinderComponent.UnregisterInputHandler(new TestInputHandler()));
        }

        [Test]
        public void RegisterHandlerAlreadyRegistered_ThrowsException()
        {
            var repeatHandler = new TestInputHandler();

            _inputBinderComponent.RegisterInputHandler(repeatHandler);
            Assert.Throws<InvalidInputHandlerException>(() => _inputBinderComponent.RegisterInputHandler(repeatHandler));
        }

        [Test]
        public void RegisterNullHandler_ThrowsException()
        {
            TestInputHandler nullHandler = null;
            Assert.Throws<InvalidInputHandlerException>(() => _inputBinderComponent.RegisterInputHandler(nullHandler));
        }

        private TestInputBinderComponent _inputBinderComponent;
        private MockInputInterface _inputInterface;
    }
}
