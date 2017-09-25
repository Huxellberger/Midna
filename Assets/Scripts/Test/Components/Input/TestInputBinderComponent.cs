﻿// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.Input
{
    public class TestInputBinderComponent
        : InputBinderComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Awake();
        }
    }
}