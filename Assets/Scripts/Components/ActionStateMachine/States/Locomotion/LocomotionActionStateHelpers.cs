// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.ActionStateMachine.States.Locomotion
{
    public static class LocomotionActionStateHelpers
    {
        public static void TransitionIntoLocomotionActionState(GameObject inGameObject)
        {
            if (inGameObject != null)
            {
                var actionStateMachineInterface = inGameObject.GetComponent<IActionStateMachineInterface>();
                if (actionStateMachineInterface != null)
                {
                    actionStateMachineInterface.RequestActionState
                    (
                        EActionStateMachineTrack.Locomotion, 
                        new LocomotionActionState(new ActionStateInfo(inGameObject))
                    );
                }
            }
        }
    }
}
