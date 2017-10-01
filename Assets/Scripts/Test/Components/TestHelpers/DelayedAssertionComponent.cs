// Copyright Threetee Gang (C) 2017

// Assert.That is probably better...
// C# 5 would be even nicer!

using System.Collections;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Test.Components.TestHelpers
{
    public delegate bool DelayedAssertionCondition();

    public class DelayedAssertionComponent 
        : MonoBehaviour
        , ITestableMonobehaviour
    {
        private DelayedAssertionCondition ConditionToEvaluate { get; set; }
        private IEnumerator ConditionCouroutine { get; set; }
        private float ConditionTimeout { get; set; }
        private float TimePassed { get; set; }
        private bool Result { get; set; }

        public void AssertDelayedCondition(DelayedAssertionCondition inCondition, float timeout = 1.0f )
        {
            ConditionTimeout = timeout;
            ConditionToEvaluate = inCondition;

            TimePassed = 0.0f;
            Result = false;

            ConditionCouroutine = DelayedEvaluation();

            StartCoroutine(ConditionCouroutine);

            while (!Result)
            {
                
            }
        }

        private IEnumerator DelayedEvaluation()
        {
            while (!ConditionToEvaluate() && TimePassed < ConditionTimeout)
            {
                TimePassed += ConditionTimeout;
                yield return new WaitForSeconds(1);
            }

            Result = true;
            if (!ConditionToEvaluate())
            {
                throw new AssertionException("Test:", "Test timed out after " + ConditionTimeout + " seconds.");
            }
        }

        public void PrepareForTest(params object[] parameters)
        {
        }
    }
}
