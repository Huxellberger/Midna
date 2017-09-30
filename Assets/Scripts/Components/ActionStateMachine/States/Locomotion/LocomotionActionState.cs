// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using Assets.Scripts.Components.MidnaMovement;

namespace Assets.Scripts.Components.ActionStateMachine.States.Locomotion
{
    public class LocomotionActionState
        : ActionState
    {
        private InputHandler LocomotionInputHandler { get; set; }
        private IInputBinderInterface InputBinderInterface { get; set; }

        public LocomotionActionState(ActionStateInfo inInfo) : base(EActionStateId.Locomotion, inInfo)
        {
            LocomotionInputHandler = new LocomotionInputHandler(inInfo.Owner.GetComponent<IMidnaMovementInterface>());
            InputBinderInterface = inInfo.Owner.GetComponent<IInputBinderInterface>();
        }

        protected override void OnStart()
        {
            if (InputBinderInterface != null)
            {
                InputBinderInterface.RegisterInputHandler(LocomotionInputHandler);
            }
        }

        protected override void OnUpdate(float deltaTime)
        {
            
        }

        protected override void OnEnd()
        {
            if (InputBinderInterface != null)
            {
                InputBinderInterface.UnregisterInputHandler(LocomotionInputHandler);
            }
        }
    }
}
