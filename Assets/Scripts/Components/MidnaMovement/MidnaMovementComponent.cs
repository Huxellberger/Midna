// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.MidnaMovement
{
    public class MidnaMovementComponent 
        : MonoBehaviour
        , IMidnaMovementInterface
    {
        public float CharacterSpeed = 2.0f;

        public float CurrentVerticalImpulse { get; private set; }
        public float CurrentHorizontalImpulse { get; private set; }

        public readonly float MaxImpulse = 1.0f;
        public readonly float MinImpulse = -1.0f;
    
        protected void Start ()
        {
            ResetImpulses();
        }
	
        protected void Update ()
        {
            transform.Translate(Vector3.right * CurrentHorizontalImpulse * CharacterSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * CurrentVerticalImpulse * CharacterSpeed * Time.deltaTime);

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
        // ~IMidnaMovementInterface

        private void ResetImpulses()
        {
            CurrentVerticalImpulse = 0.0f;
            CurrentHorizontalImpulse = 0.0f;
        }
    }
}
