// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using Assets.Scripts.Components.ActionStateMachine.ConditionRunner;
using Assets.Scripts.Components.ActionStateMachine.ConditionRunner.Conditions;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Components.Input;
using Assets.Scripts.Components.UnityEvent;

namespace Assets.Scripts.Components.ActionStateMachine.States.Dead
{
    public class DeadActionState
        : ActionState
    {
        // Need to parameterize these ideally, still debating method here
        public readonly float DeathDelay = 5.0f;
        public readonly List<EInputKey> AcceptableInputs = new List<EInputKey>{EInputKey.SelectButton};

        private IUnityMessageEventInterface DispatcherInterface { get; set; }
        private ActionStateConditionRunner DeadActionStateConditions { get; set; }

        public DeadActionState(ActionStateInfo inInfo) : base(EActionStateId.Dead, inInfo)
        {
            DeadActionStateConditions = new ActionStateConditionRunner();
        }

        protected override void OnStart()
        {
            DispatcherInterface = Info.Owner.GetComponent<IUnityMessageEventInterface>();
            DispatcherInterface.GetUnityMessageEventDispatcher().InvokeMessageEvent(new EnteredDeadActionStateMessage());

            InitialiseConditions();
        }

        protected override void OnUpdate(float deltaTime)
        {
            DeadActionStateConditions.Update(deltaTime);

            if (DeadActionStateConditions.IsComplete())
            {
                if (MidnaGameMode.CurrentGameMode)
                {
                    UnityMessageEventFunctions.InvokeMessageEventWithDispatcher(GameMode.MidnaGameMode.CurrentGameMode, new RequestRespawnMessage(Info.Owner));
                }
            }
        }

        protected override void OnEnd()
        {
            DispatcherInterface.GetUnityMessageEventDispatcher().InvokeMessageEvent(new LeftDeadActionStateMessage());
        }

        private void InitialiseConditions()
        {
            DeadActionStateConditions.AddCondition(new DelayActionStateCondition(DeathDelay));
            DeadActionStateConditions.PushNewTrack();
            DeadActionStateConditions.AddCondition(new InputReceivedActionStateCondition(AcceptableInputs, Info.Owner.GetComponent<IInputBinderInterface>()));
        }
    }
}
