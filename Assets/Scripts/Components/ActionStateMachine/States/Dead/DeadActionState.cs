// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.ActionStateMachine.States.Dead
{
    public class DeadActionState
        : ActionState
    {
        public DeadActionState(ActionStateInfo inInfo) : base(EActionStateId.Dead, inInfo)
        {
        }

        protected override void OnStart()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnEnd()
        {
            throw new System.NotImplementedException();
        }
    }
}
