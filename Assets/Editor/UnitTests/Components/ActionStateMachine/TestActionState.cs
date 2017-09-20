// Copyright Threetee Gang (C) 2017

using Midna.Components.ActionStateMachine;

namespace Midna.Editor.UnitTests.Components.ActionStateMachine
{
    public class TestActionState : ActionState
    {
        public TestActionState()
            : base()
        {
            onStartCalled = false;
            onUpdateCalled = false;
            onEndCalled = false;
        }

        protected override void OnStart()
        {
            onStartCalled = true;
        }

        protected override void OnUpdate(float deltaTime)
        {
            onUpdateCalled = true;
            onUpdateValue = deltaTime;
        }

        protected override void OnEnd()
        {
            onEndCalled = true;
        }

        public bool onStartCalled { get; set; }
        public bool onUpdateCalled { get; set; }
        public float ? onUpdateValue { get; set; }
        public bool onEndCalled { get; set; }
    }
}
