// Copyright Threetee Gang (C) 2017

namespace Midna.Components.ActionStateMachine
{
    public interface IActionStateMachineInterface
    {
        void RequestActionState(EActionStateMachineTrack selectedTrack, EActionStateId newId);

        bool IsActionStateActiveOnTrack(EActionStateMachineTrack selectedTrack, EActionStateId expectedId);
    }
}
