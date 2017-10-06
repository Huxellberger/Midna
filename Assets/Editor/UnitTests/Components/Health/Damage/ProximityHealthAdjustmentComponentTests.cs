﻿// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Components.Health;
using Assets.Scripts.Test.Components.Health.Damage;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.Health.Damage
{
    [TestFixture]
    public class ProximityHealthAdjustmentComponentTestFixture
    {
        [Test]
        public void OnCollision_AdjustsHealthBySpecifiedAmount()
        {
            var healthComponent =
                TestableMonobehaviourFunctions<MockHealthComponent>.PrepareMonobehaviourComponentForTest();

            var adjustComponent = TestableMonobehaviourFunctions<TestProximityHealthAdjustmentComponent>
                .PrepareMonobehaviourComponentForTest();

            adjustComponent.HealthChangeOnContact = 12;
            adjustComponent.TestCollide(healthComponent.gameObject);

            Assert.AreEqual(adjustComponent.HealthChangeOnContact, healthComponent.AdjustHealthResult);
        }
    }
}
