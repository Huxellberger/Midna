// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.MidnaMovement
{
    public interface IMidnaMovementInterface
    {
        void AddVerticalImpulse(float inVertImpulse);
        void AddHorizontalImpulse(float inHorImpulse);
        void ToggleSprint(bool enable);
    }
}
