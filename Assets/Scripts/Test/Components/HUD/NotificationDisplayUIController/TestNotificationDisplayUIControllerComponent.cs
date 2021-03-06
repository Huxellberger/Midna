﻿// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.HUD.NotificationDisplayUIController;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.HUD.NotificationDisplayUIController
{
    public class TestNotificationDisplayUIControllerComponent 
        : NotificationDisplayUIControllerComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Start();
        }
    }
}

#endif
