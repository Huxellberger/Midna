// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.ActionStateMachine.ConditionRunner.Conditions;
using Assets.Scripts.Components.Input;
using Assets.Scripts.Test.Components.Input;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.ActionStateMachine.ConditionRunner.Conditions
{
    [TestFixture]
    public class InputReceivedActionStateConditionTestFixture
    {
        private readonly List<EInputKey> _expectedInputs = new List<EInputKey> {EInputKey.FireButton, EInputKey.HorizontalAnalog};
        private readonly EInputKey _unexpectedInput = EInputKey.VerticalAnalog;

        [Test]
        public void Start_RegistersHandler()
        {
            var inputBinder = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();

            var condition = new InputReceivedActionStateCondition(_expectedInputs, inputBinder);

            condition.Start();

            Assert.NotNull(inputBinder.RegisteredHandler);
        }

        [Test]
        public void ReceivesWrongInput_DoesNotComplete()
        {
            var inputBinder = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();

            var condition = new InputReceivedActionStateCondition(_expectedInputs, inputBinder);

            condition.Start();

            inputBinder.RegisteredHandler.HandleButtonInput(_unexpectedInput, true);

            Assert.IsFalse(condition.Complete);
        }

        [Test]
        public void ReceivesCorrectInput_Completes()
        {
            var inputBinder = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();

            var condition = new InputReceivedActionStateCondition(_expectedInputs, inputBinder);

            condition.Start();

            inputBinder.RegisteredHandler.HandleButtonInput(_expectedInputs.First(), true);

            Assert.IsTrue(condition.Complete);
        }

        [Test]
        public void End_UnregistersHandler()
        {
            var inputBinder = TestableMonobehaviourFunctions<MockInputBinderComponent>
                .PrepareMonobehaviourComponentForTest();

            var condition = new InputReceivedActionStateCondition(_expectedInputs, inputBinder);

            condition.Start();
            condition.End();

            Assert.NotNull(inputBinder.UnregisteredHandler);
        }
    }
}

#endif
