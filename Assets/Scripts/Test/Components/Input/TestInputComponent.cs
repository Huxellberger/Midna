// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Editor.UnitTests.Components.Input
{
    public class TestInputComponent
        : InputComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Awake();
        }

        public void TestUpdate()
        {
            Update();
        }
    }
}
