// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;

namespace Assets.Scripts.Components.ActionStateMachine.States.Locomotion
{
    public class LocomotionActionState
        : ActionState
    {
        private InputHandler locomotionInputHandler { get; set; }

        public LocomotionActionState(ActionStateInfo inInfo) : base(EActionStateId.Locomotion, inInfo)
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
