// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Components.Equipment.EquipmentItem;
using Assets.Scripts.Test.TestableMonobehaviour;
using UnityEngine;

public class TestCane 
    : Cane
    , ITestableMonobehaviour
{
    public float deltaTime { get; set; }

    public void TestUpdate()
    {
        Update();
    }

    public void TestCollide(GameObject inGameObject)
    {
        OnGameObjectCollides(inGameObject);
    }

    public void PrepareForTest(params object[] parameters)
    {
        Start();
    }

    protected override float GetDeltaTime()
    {
        return deltaTime;
    }
}

#endif
