// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Test.Components.Character;
using Assets.Scripts.Test.Components.Spawn;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.Spawn
{
    [TestFixture]
    public class ProximitySpawnComponentTestFixture {

        [Test]
        public void OnCollisionEnter_HasCharacterComponent_TriggersSpawnUpdate()
        {
            var spawnComponent = TestableMonobehaviourFunctions<TestProximitySpawnComponent>
                .PrepareMonobehaviourComponentForTest();

            var character = TestableMonobehaviourFunctions<TestMidnaCharacterComponent>
                .PrepareMonobehaviourComponentForTest().gameObject;

            spawnComponent.TestCollision(character.gameObject);

            Assert.IsTrue(spawnComponent.TriggeredSpawnUpdate);
        }

        [Test]
        public void OnCollisionEnter_NoCharacterComponent_DoesNotTriggersSpawnUpdate()
        {
            var spawnComponent = TestableMonobehaviourFunctions<TestProximitySpawnComponent>
                .PrepareMonobehaviourComponentForTest();

            var character = new GameObject();

            spawnComponent.TestCollision(character);

            Assert.IsFalse(spawnComponent.TriggeredSpawnUpdate);
        }
    }
}
