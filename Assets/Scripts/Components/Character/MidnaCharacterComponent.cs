// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.States.Locomotion;
using Assets.Scripts.Components.GameMode;
using Assets.Scripts.Components.Input;
using UnityEngine;

namespace Assets.Scripts.Components.Character
{
    public class MidnaCharacterComponent 
        : MonoBehaviour
    {
        protected void Start ()
        {
            var inputInterface = MidnaGameMode.CurrentGameMode.GetComponent<IInputInterface>();
            GetComponent<IInputBinderInterface>().SetInputInterface(inputInterface);

            LocomotionActionStateHelpers.TransitionIntoLocomotionActionState(gameObject);
        }
    }
}
