// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.MidnaMovement;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.MidnaMovement
{
    public class TestMidnaMovementComponent
        : MidnaMovementComponent
        , ITestableMonobehaviour
    {
        public float DeltaTime { get; set; }

        public void PrepareForTest(params object[] parameters)
        {
            Start();
        }

        public void TestUpdate()
        {
            Update();
        }

        protected override float GetDeltaTime()
        {
            return DeltaTime;
        }
    }
}
