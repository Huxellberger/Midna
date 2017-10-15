// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Integration
{
    public class TestIntegrationTestComponent 
        : IntegrationTestComponent 
            , ITestableMonobehaviour
    {
        public bool RunTestImplCalled { get; private set; }

        protected override void RunTestImpl()
        {
            RunTestImplCalled = true;
        }

        public void PrepareForTest(params object[] parameters)
        {
            Awake();
        }
    }
}
