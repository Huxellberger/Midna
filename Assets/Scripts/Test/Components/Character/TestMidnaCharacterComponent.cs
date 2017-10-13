// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Character;
using Assets.Scripts.Components.Controller;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.Character
{
    public class TestMidnaCharacterComponent 
        : MidnaCharacterComponent 
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Start();
        }

        public void TestDestroy()
        {
            OnDestroy();
        }
    }
}
