// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.ActionStateMachine.States.AwaitingSpawn
{
    public static class AwaitingSpawnActionStateHelpers
    {
        public static void TransitionIntoAwaitingSpawnActionState(GameObject inGameObject)
        {
            if (inGameObject != null)
            {
                var actionStateMachineInterface = inGameObject.GetComponent<IActionStateMachineInterface>();
                if (actionStateMachineInterface != null)
                {
                    actionStateMachineInterface.RequestActionState
                    (
                        EActionStateMachineTrack.Locomotion,
                        new AwaitingSpawnActionState(new ActionStateInfo(inGameObject))
                    );
                }
            }
        }
    }
}
