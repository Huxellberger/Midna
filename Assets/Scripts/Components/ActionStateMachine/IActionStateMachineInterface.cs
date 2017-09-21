// Copyright Threetee Gang (C) 2017

namespace Midna.Components.ActionStateMachine
{
    public interface IActionStateMachineInterface
    {
        void RequestActionState(EActionStateMachineTrack selectedTrack, ActionState newState);

        bool IsActionStateActiveOnTrack(EActionStateMachineTrack selectedTrack, EActionStateId expectedId);
    }
}
