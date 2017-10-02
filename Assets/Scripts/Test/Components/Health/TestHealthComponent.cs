﻿// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Health;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.Health
{
    public class TestHealthComponent 
        : HealthComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Start();
        }
    }
}
