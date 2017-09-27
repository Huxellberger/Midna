// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using Assets.Scripts.Components.Input;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.CloudBuild.BuildSteps
{
    public static class ReadInputManager
    {
        public static List<RawInput> GetRawInputsFromInputManager()
        {
            var allRawInputs = new List<RawInput>();

            var serialisedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            
            var serialisedProperty = serialisedObject.FindProperty("m_Axes");
            serialisedProperty.Next(true);
            serialisedProperty.Next(true);

            while (serialisedProperty.Next(false))
            {
                var axis = serialisedProperty.Copy();
                axis.Next(true);
                if (axis.stringValue.Contains("Analog"))
                {
                    allRawInputs.Add(new RawInput(axis.stringValue, EInputType.Analog));
                }
                else if (axis.stringValue.Contains("Button"))
                {
                    allRawInputs.Add(new RawInput(axis.stringValue, EInputType.Button));
                }
                else if (axis.stringValue.Contains("Mouse"))
                {
                    allRawInputs.Add(new RawInput(axis.stringValue, EInputType.Mouse));
                }
            }
            return allRawInputs;
        }

        public static string ConvertInputManagerToJson()
        {
            var allRawInputs = GetRawInputsFromInputManager();

            var output = JsonUtility.ToJson(allRawInputs);

            Debug.Log("Input manager as JSON:\n" + output);

            return output;
        }
        
    }
}
