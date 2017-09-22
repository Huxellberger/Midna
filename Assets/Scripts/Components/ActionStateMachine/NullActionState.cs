// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.ActionStateMachine
{
    public class NullActionState : ActionState
    {
        public NullActionState()
            : base(EActionStateId.Null)
        {
        }

        protected override void OnStart() { }
        protected override void OnUpdate(float deltaTime) { }
        protected override void OnEnd() { }
    }
}
