// Copyright Threetee Gang (C) 2017

using Assets.Editor.UnitTests.Helpers;
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

            _midnaMovementComponent.DeltaTime = _midnaMovementComponent.SprintMaxTimer * 0.8f;
            _startPosition = _midnaMovementComponent.transform.position;
        }

        [TearDown]
        public void AfterTest()
        {
            _midnaMovementComponent = null;
        }

        private void ExceedSprintTimer()
        {
            float CurrentTimer = _midnaMovementComponent.SprintMaxTimer;

            while (CurrentTimer > 0.0f)
            {
                _midnaMovementComponent.AddHorizontalImpulse(1.0f);
                _midnaMovementComponent.AddVerticalImpulse(1.0f);

                _midnaMovementComponent.TestUpdate();
                CurrentTimer -= _midnaMovementComponent.DeltaTime;
            }
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
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime, 
                0.0f
            ) +_startPosition;

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

        [Test]
        public void Update_SprintEnabled_AppliesModiferToTransform()
        {
            _midnaMovementComponent.PrepareForTest();

            const float horizontalImpulse = 0.3f;

            const float verticalImpulse = 0.2f;

            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            _midnaMovementComponent.ToggleSprint(true);

            var expectedVector = new Vector3
            (  
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.SprintModifier,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.SprintModifier,
                0.0f
            ) 
            + _startPosition;

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        [Test]
        public void Update_SprintEnabledAndExceedMaxTime_AppliesFatigueModiferToTransform()
        {
            _midnaMovementComponent.PrepareForTest();

            _midnaMovementComponent.ToggleSprint(true);
            ExceedSprintTimer();
            _startPosition = _midnaMovementComponent.transform.position;

            const float horizontalImpulse = 0.3f;

            const float verticalImpulse = 0.2f;

            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            var expectedVector = new Vector3
            (
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.FatigueModifier,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.FatigueModifier,
                0.0f
            ) 
            + _startPosition;

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        [Test]
        public void Update_SprintEnabledAndExceedMaxTime_AppliesNormalModifierAfterSprintTransform()
        {
            _midnaMovementComponent.PrepareForTest();

            _midnaMovementComponent.ToggleSprint(true);
            ExceedSprintTimer();
            ExceedSprintTimer();
            _startPosition = _midnaMovementComponent.transform.position;

            const float horizontalImpulse = 0.3f;

            const float verticalImpulse = 0.2f;

            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            var expectedVector = new Vector3
            (
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime,
                0.0f
            ) 
            + _startPosition;

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        [Test]
        public void Update_SprintEnabledAndExceedMaxTime_TogglingSprintOffStopsFatigue()
        {
            _midnaMovementComponent.PrepareForTest();

            _midnaMovementComponent.ToggleSprint(true);

            _midnaMovementComponent.DeltaTime = _midnaMovementComponent.SprintMaxTimer * 0.6f;

            const float horizontalImpulse = 0.3f;
            const float verticalImpulse = 0.2f;

            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            _midnaMovementComponent.TestUpdate();

            _midnaMovementComponent.ToggleSprint(false);

            _startPosition = _midnaMovementComponent.transform.position;
            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            var expectedVector = new Vector3
            (
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime,
                0.0f
            )
            + _startPosition;

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        [Test]
        public void Update_SprintEnabledAndExceedMaxTime_TogglingSprintOffDelaysFatigue()
        {
            _midnaMovementComponent.PrepareForTest();

            _midnaMovementComponent.ToggleSprint(true);

            _midnaMovementComponent.DeltaTime = _midnaMovementComponent.SprintMaxTimer * 0.6f;

            const float horizontalImpulse = 0.3f;
            const float verticalImpulse = 0.2f;

            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            _midnaMovementComponent.TestUpdate();

            _midnaMovementComponent.ToggleSprint(false);
            _midnaMovementComponent.TestUpdate();

            // We shouldn't become fatigued here
            _midnaMovementComponent.ToggleSprint(true);
            _startPosition = _midnaMovementComponent.transform.position;
            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            var expectedVector = new Vector3
            (
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.SprintModifier,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.SprintModifier,
                0.0f
            )
            + _startPosition;

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        [Test]
        public void Update_SprintEnabledAndNoInput_DoesNotBecomeFatigued()
        {
            _midnaMovementComponent.PrepareForTest();

            _midnaMovementComponent.ToggleSprint(true);

            _midnaMovementComponent.DeltaTime = _midnaMovementComponent.SprintMaxTimer * 0.6f;

            _midnaMovementComponent.TestUpdate();
            _midnaMovementComponent.TestUpdate();

            const float horizontalImpulse = 0.3f;
            const float verticalImpulse = 0.2f;

            _startPosition = _midnaMovementComponent.transform.position;
            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            var expectedVector = new Vector3
            (
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.SprintModifier,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.SprintModifier,
                0.0f
            )
            + _startPosition;

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        [Test]
        public void Update_SprintToggled_DoesNotResetSprintTimer()
        {
            _midnaMovementComponent.PrepareForTest();

            _midnaMovementComponent.ToggleSprint(true);

            _midnaMovementComponent.DeltaTime = _midnaMovementComponent.SprintMaxTimer * 0.6f;

            const float horizontalImpulse = 0.3f;
            const float verticalImpulse = 0.2f;

            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            _midnaMovementComponent.TestUpdate();

            _midnaMovementComponent.ToggleSprint(false);

            // We will become fatigued since the threshold won't have reset
            _midnaMovementComponent.ToggleSprint(true);
            _startPosition = _midnaMovementComponent.transform.position;
            _midnaMovementComponent.AddHorizontalImpulse(horizontalImpulse);
            _midnaMovementComponent.AddVerticalImpulse(verticalImpulse);

            var expectedVector = new Vector3
            (
                1 * horizontalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.FatigueModifier,
                1 * verticalImpulse * _midnaMovementComponent.CharacterSpeed * _midnaMovementComponent.DeltaTime * _midnaMovementComponent.FatigueModifier,
                0.0f
            )
            + _startPosition;

            _midnaMovementComponent.TestUpdate();

            Assert.AreEqual(expectedVector, _midnaMovementComponent.transform.position);
        }

        private Vector3 _startPosition;
        private TestMidnaMovementComponent _midnaMovementComponent;
    }
}
