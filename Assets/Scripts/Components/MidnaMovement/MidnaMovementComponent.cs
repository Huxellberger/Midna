// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.MidnaMovement
{
    public class MidnaMovementComponent 
        : MonoBehaviour
        , IMidnaMovementInterface
    {
        public float CharacterSpeed = 2.0f;
        public float SprintModifier = 2.0f;

        public float CurrentVerticalImpulse { get; private set; }
        public float CurrentHorizontalImpulse { get; private set; }

        public readonly float MaxImpulse = 1.0f;
        public readonly float MinImpulse = -1.0f;

        private bool Sprinting { get; set; }
    
        protected void Start ()
        {
            Sprinting = false;
            ResetImpulses();
        }
	
        protected void Update ()
        {
            transform.Translate(Vector3.right * CurrentHorizontalImpulse * CharacterSpeed * Time.deltaTime * (Sprinting ? SprintModifier : 1));
            transform.Translate(Vector3.up * CurrentVerticalImpulse * CharacterSpeed * Time.deltaTime * (Sprinting ? SprintModifier : 1));

            ResetImpulses();
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
            Sprinting = enable;
        }
        // ~IMidnaMovementInterface

        private void ResetImpulses()
        {
            CurrentVerticalImpulse = 0.0f;
            CurrentHorizontalImpulse = 0.0f;
        }
    }
}
