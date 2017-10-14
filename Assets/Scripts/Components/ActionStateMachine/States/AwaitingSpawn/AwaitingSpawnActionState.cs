// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.ConditionRunner;
using Assets.Scripts.Components.ActionStateMachine.ConditionRunner.Conditions;
using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.UnityEvent;

namespace Assets.Scripts.Components.ActionStateMachine.States.AwaitingSpawn
{
    public class AwaitingSpawnActionState 
        : ActionState
    {
        public static float FadeTime = 5.0f;
        private ActionStateConditionRunner Conditions { get; set; }
        public AwaitingSpawnActionState(ActionStateInfo inInfo) : base(EActionStateId.AwaitingSpawn, inInfo)
        {
            Conditions = new ActionStateConditionRunner();
        }

        protected override void OnStart()
        {
            InitialiseConditions();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Conditions.Update(deltaTime);

            if (Conditions.IsComplete())
            {
                LocomotionActionStateHelpers.TransitionIntoLocomotionActionState(Info.Owner);
            }
        }

        protected override void OnEnd()
        {
        }

        private void InitialiseConditions()
        {
            Conditions.AddCondition(new CameraFadeCompleteCondition(0.0f, FadeTime, Info.Owner.GetComponent<IUnityMessageEventInterface>()));
        }
    }
}
