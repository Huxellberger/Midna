// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.Controller
{
    public class ControllerComponent : MonoBehaviour
    {
        protected GameObject PawnInstance { get; set; }

        public void CreatePawnOfType(GameObject inPawnType)
        {
            PawnInstance = Instantiate(inPawnType);
        }

        public void SetPawn(GameObject inPawnInstance)
        {
            PawnInstance = inPawnInstance;
        }

        public void DestroyPawn()
        {
            Destroy(PawnInstance);
        }
    }
}
