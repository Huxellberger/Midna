// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.Controller
{
    public class ControllerComponent : MonoBehaviour
    {
        public int PerspectiveDistance = -10;
        protected GameObject PawnInstance { get; set; }

        public void CreatePawnOfType(GameObject inPawnType)
        {
            PawnInstance = Instantiate(inPawnType);
            UpdateTransformParent();
        }

        public void SetPawn(GameObject inPawnInstance)
        {
            PawnInstance = inPawnInstance;
            UpdateTransformParent();
        }

        public void DestroyPawn()
        {
            Destroy(PawnInstance);
        }

        private void UpdateTransformParent()
        {
            transform.parent = PawnInstance.transform;
            transform.localPosition = new Vector3(0, 0, PerspectiveDistance);
        }
    }
}
