// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.ConditionRunner;
using Assets.Scripts.Components.UnityEvent;

namespace Assets.Scripts.Components.ActionStateMachine.States.Dead
{
    public class DeadActionState
        : ActionState
    {
        private IUnityMessageEventInterface DispatcherInterface { get; set; }
        private ActionStateConditionRunner DeadActionStateConditions { get; set; }

        public DeadActionState(ActionStateInfo inInfo) : base(EActionStateId.Dead, inInfo)
        {
            // Wait
            // Push Button
            DeadActionStateConditions = new ActionStateConditionRunner();
        }

        protected override void OnStart()
        {
            DispatcherInterface = Info.Owner.GetComponent<IUnityMessageEventInterface>();
            DispatcherInterface.GetUnityMessageEventDispatcher().InvokeMessageEvent(new EnteredDeadActionStateMessage());
        }

        protected override void OnUpdate(float deltaTime)
        {

            if (DeadActionStateConditions.IsComplete())
            {
                // Request Respawn
            }
        }

        protected override void OnEnd()
        {
            DispatcherInterface.GetUnityMessageEventDispatcher().InvokeMessageEvent(new LeftDeadActionStateMessage());
        }
    }
}
