// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Test.Integration
{
    public abstract class IntegrationTestComponent 
        : MonoBehaviour
    {
        public bool Passed;

        protected void Awake ()
        {
            Passed = false;
		    RunTestImpl();
        }

        protected abstract void RunTestImpl();
    }
}
