// Copyright Threetee Gang (C) 2017

using System;
using UnityEngine;

namespace Assets.Scripts.Components.MidnaMovement
{
    public class MidnaMovementComponent 
        : MonoBehaviour
        , IMidnaMovementInterface
    {
        private enum ESprintState
        {
            Sprinting,
            NotSprinting,
            Fatigued
        }

        private enum EOrientation
        {
            Right,
            Left,
            Down,
            Up
        }

        public float CharacterSpeed = 2.0f;
        public float SprintModifier = 2.0f;
        public float FatigueModifier = 0.5f;
        public float SprintMaxTimer = 5.0f;

        public float CurrentVerticalImpulse { get; private set; }
        public float CurrentHorizontalImpulse { get; private set; }

        public readonly float MaxImpulse = 1.0f;
        public readonly float MinImpulse = -1.0f;

        private ESprintState SprintState { get; set; }
        private EOrientation PriorOrientation { get; set; }
        private float CurrentSprintTime { get; set; }
    
        protected void Start ()
        {
            PriorOrientation = EOrientation.Up;
            SprintState = ESprintState.NotSprinting;
            CurrentSprintTime = 0.0f;

            ResetImpulses();
        }
	
        protected void Update ()
        {
            float deltaTime = GetDeltaTime();
            UpdateSprintState(deltaTime);
            UpdateRotation();
            var actualSprintModifier = GetSprintModifier();

            transform.position += (Vector3.right * CurrentHorizontalImpulse * CharacterSpeed * deltaTime * actualSprintModifier);
            transform.position += (Vector3.up * CurrentVerticalImpulse * CharacterSpeed * deltaTime * actualSprintModifier);

            ResetImpulses();
        }

        private void UpdateRotation()
        {
            var currentOrientation = GetCurrentOrientation();
            if (currentOrientation != PriorOrientation)
            {
                var priorAngle = GetAngleForOrientation(PriorOrientation);
                var currentAngle = GetAngleForOrientation(currentOrientation);

                gameObject.transform.Rotate(Vector3.back, currentAngle - priorAngle, Space.World);

                PriorOrientation = currentOrientation;
            }
        }

        private EOrientation GetCurrentOrientation()
        {
            if (CurrentVerticalImpulse > 0.0f)
            {
                return EOrientation.Up;
            }
            if (CurrentVerticalImpulse < 0.0f)
            {
                return EOrientation.Down;
            }

            if (CurrentHorizontalImpulse > 0.0f)
            {
                return EOrientation.Right;
            }
            if (CurrentHorizontalImpulse < 0.0f)
            {
                return EOrientation.Left;
            }

            return PriorOrientation;
        }

        private float GetAngleForOrientation(EOrientation currentOrientation)
        {
            switch (currentOrientation)
            {
                case EOrientation.Down:
                    return 180f;
                case EOrientation.Up:
                    return 0f;
                case EOrientation.Right:
                    return 45f;
                case EOrientation.Left:
                    return 270f;
                default:
                    return 0f;
            }
        }

        private void UpdateSprintState(float deltaTime)
        {
            if (
                    (SprintState == ESprintState.Sprinting || SprintState == ESprintState.Fatigued)
                    && IsMoving()
                )
            {
                CurrentSprintTime += deltaTime;

                if (CurrentSprintTime >= SprintMaxTimer)
                {
                    CurrentSprintTime = 0.0f;
                    SprintState = (SprintState == ESprintState.Sprinting ? ESprintState.Fatigued : ESprintState.NotSprinting);
                }
            }
            else
            {
                if (CurrentSprintTime > 0.0f)
                {
                    CurrentSprintTime = Mathf.Clamp(CurrentSprintTime - deltaTime, 0.0f, SprintMaxTimer);
                }
            }
        }

        private bool IsMoving()
        {
            return Math.Abs(CurrentVerticalImpulse) > 0.01f || Math.Abs(CurrentHorizontalImpulse) > 0.01f;
        }

        private float GetSprintModifier()
        {
            switch (SprintState)
            {
                case ESprintState.Sprinting:
                    return SprintModifier;
                case ESprintState.Fatigued:
                    return FatigueModifier;
                case ESprintState.NotSprinting:
                default:
                    return 1.0f;
            }
        }

        protected virtual float GetDeltaTime()
        {
            return Time.deltaTime;
        }

        // IMidnaMovementInterface
        public void AddVerticalImpulse(float inVertImpulse)
        {
            CurrentVerticalImpulse = Mathf.Clamp(CurrentVerticalImpulse + inVertImpulse, MinImpulse, MaxImpulse);
        }

        public void AddHorizontalImpulse(float inHorImpulse)
        {
            CurrentHorizontalImpulse = Mathf.Clamp(CurrentHorizontalImpulse + inHorImpulse, MinImpulse, MaxImpulse);
        }

        public void ToggleSprint(bool enable)
        {
            if (enable && SprintState == ESprintState.NotSprinting)
            {
                SprintState = ESprintState.Sprinting;
            }
            else if (SprintState == ESprintState.Sprinting)
            {
                SprintState = ESprintState.NotSprinting;
            }
        }
        // ~IMidnaMovementInterface

        private void ResetImpulses()
        {
            CurrentVerticalImpulse = 0.0f;
            CurrentHorizontalImpulse = 0.0f;
        }
    }
}
