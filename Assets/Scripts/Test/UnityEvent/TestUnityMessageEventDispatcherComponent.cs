// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.UnityEvent;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.UnityEvent
{
    public class TestUnityMessageEventDispatcherComponent
        : UnityMessageEventDispatcherComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Awake();
        }
    }
}

#endif
