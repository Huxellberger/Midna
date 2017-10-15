// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Equipment;
using Assets.Scripts.Test.TestableMonobehaviour;

namespace Assets.Scripts.Test.Components.Equipment
{
    public class TestEquipmentComponent 
        : EquipmentComponent
        , ITestableMonobehaviour
    {
        public void PrepareForTest(params object[] parameters)
        {
            Start();
        }
    }
}
