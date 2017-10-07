﻿// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Character;
using Assets.Scripts.UnityLayer.GameObjects;
using UnityEngine;

namespace Assets.Scripts.Components.Controller
{
    public class ControllerComponent : MonoBehaviour
    {
        public int PerspectiveDistance = -10;
        public GameObject PawnInstance { get; protected set; }
        public Transform PawnInitialTransform { get; set; }

        public void CreatePawnOfType(GameObject inPawnType)
        {
            if (PawnInitialTransform != null)
            {
                SetPawn(Instantiate(inPawnType, PawnInitialTransform.localPosition, PawnInitialTransform.localRotation));
            }
            else
            {
                SetPawn(Instantiate(inPawnType));
            }
        }

        public void SetPawn(GameObject inPawnInstance)
        {
            PawnInstance = inPawnInstance;

            // Characters need their controller updating
            var midnaCharacterComponent = PawnInstance.GetComponent<MidnaCharacterComponent>();
            if (midnaCharacterComponent != null)
            {
                midnaCharacterComponent.CurrentControllerComponent = this;
            }

            UpdateTransformParent();
        }

        public void DestroyPawn()
        {
            transform.parent = null;
            DestructionFunctions.DestroyGameObject(PawnInstance);
        }

        private void UpdateTransformParent()
        {
            transform.parent = PawnInstance.transform;
            transform.localPosition = new Vector3(0, 0, PerspectiveDistance);
        }
    }
}
