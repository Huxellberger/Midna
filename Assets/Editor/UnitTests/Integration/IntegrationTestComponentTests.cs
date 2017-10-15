// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Integration;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Integration
{
    public class IntegrationTestComponentTestFixture
    {
        [Test]
        public void Awake_RunTestImplCalled()
        {
            var integrationTestComponent = TestableMonobehaviourFunctions<TestIntegrationTestComponent>
                .PrepareMonobehaviourComponentForTest();

            Assert.IsTrue(integrationTestComponent.RunTestImplCalled);
        }

        [Test]
        public void Awake_PassedFalse()
        {
            var integrationTestComponent = TestableMonobehaviourFunctions<TestIntegrationTestComponent>
                .PrepareMonobehaviourComponentForTest();

            Assert.IsFalse(integrationTestComponent.Passed);
        }
    }
}
