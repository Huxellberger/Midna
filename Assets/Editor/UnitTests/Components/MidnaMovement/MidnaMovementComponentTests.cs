// Copyright Threetee Gang (C) 2017

using System.Runtime.InteropServices;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Core;
using Assets.Scripts.Test.Components.MidnaMovement;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests.Components.MidnaMovement
{
    [TestFixture]
    public class MidnaMovementComponentTestFixture
    {
        [SetUp]
        public void BeforeTest()
        {
            _midnaMovementComponent = TestableMonobehaviourFunctions<TestMidnaMovementComponent>
                .PrepareMonobehaviourComponentForTest();
        }

        [TearDown]
        public void AfterTest()
        {
            _midnaMovementComponent = null;
        }

        [Test]
        public void Start_ImpulsesAreZero()
        {
            _midnaMovementComponent.PrepareForTest();

            Assert.AreEqual(0.0f, _midnaMovementComponent.CurrentHorizontalImpulse);
            Assert.AreEqual(0.0f, _midnaMovementComponent.CurrentVerticalImpulse);
        }

        [Test]
        public void AddVerticalImpulse_AddsImpulse()
        {
            _midnaMovementComponent.PrepareForTest();

            const float firstImpulse = 0.1f;
            const float secondImpulse = -0.3f;

            _midnaMovementComponent.AddVerticalImpulse(firstImpulse);
            _midnaMovementComponent.AddVerticalImpulse(secondImpulse);

            Assert.AreEqual(firstImpulse + secondImpulse, _midnaMovementComponent.CurrentVerticalImpulse);
        }

        [Test]
        public void AddVerticalImpulse_ClampsToMaxValue()
        {
            _midnaMovementComponent.PrepareForTest();

            var exceedingImpulse = _midnaMovementComponent.MaxImpulse + 0.1f;

            _midnaMovementComponent.AddVerticalImpulse(exceedingImpulse);

            Assert.AreEqual(_midnaMovementComponent.MaxImpulse, _midnaMovementComponent.CurrentVerticalImpulse);
        }

        [Test]
        public void AddVerticalImpulse_ClampsToMinValue()
        {
            _midnaMovementComponent.PrepareForTest();

            var exceedingImpulse = _midnaMovementComponent.MinImpulse - 0.1f;

            _midnaMovementComponent.AddVerticalImpulse(exceedingImpulse);

            Assert.AreEqual(_midnaMovementComponent.MinImpulse, _midnaMovementComponent.CurrentVerticalImpulse);
        }

        [Test]
        public void AddHorizontalImpulse_AddsImpulse()
        {
            _midnaMovementComponent.PrepareForTest();

            const float firstImpulse = 0.1f;
            const float secondImpulse = -0.3f;

            _midnaMovementComponent.AddHorizontalImpulse(firstImpulse);
            _midnaMovementComponent.AddHorizontalImpulse(secondImpulse);

            Assert.AreEqual(firstImpulse + secondImpulse, _midnaMovementComponent.CurrentHorizontalImpulse);
        }

        [Test]
        public void AddHorizontalImpulse_ClampsToMaxValue()
        {
            _midnaMovementComponent.PrepareForTest();

            var exceedingImpulse = _midnaMovementComponent.MaxImpulse + 0.1f;

            _midnaMovementComponent.AddHorizontalImpulse(exceedingImpulse);

            Assert.AreEqual(_midnaMovementComponent.MaxImpulse, _midnaMovementComponent.CurrentHorizontalImpulse);
        }

        [Test]
        public void AddHorizontalImpulse_ClampsToMinValue()
        {
            _midnaMovementComponent.PrepareForTest();

            var exceedingImpulse = _midnaMovementComponent.MinImpulse - 0.1f;

            _midnaMovementComponent.AddHorizontalImpulse(exceedingImpulse);

            Assert.AreEqual(_midnaMovementComponent.MinImpulse, _midnaMovementComponent.CurrentHorizontalImpulse);
        }

        [Test]
        public void Update_UpdatesTransformUsingImpulseValues()
        {
            _midnaMovementComponent.PrepareForTest();

            const float horizontalImpulse = 0.3f;

            const float verticalImpulse = 0.2f;

            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            var expectedVector = new Vector3
            (
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * Time.deltaTime,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * Time.deltaTime, 
                0.0f
            );

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        [Test]
        public void Update_ResetsImpulses()
        {
            _midnaMovementComponent.PrepareForTest();

            _midnaMovementComponent.AddHorizontalImpulse(0.3f);
            _midnaMovementComponent.AddVerticalImpulse(-0.2f);

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(0.0f, _midnaMovementComponent.CurrentHorizontalImpulse);
            Assert.AreEqual(0.0f, _midnaMovementComponent.CurrentVerticalImpulse);
        }

        private TestMidnaMovementComponent _midnaMovementComponent;
    }
}
