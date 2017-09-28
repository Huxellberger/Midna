// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif // UNITY_EDITOR

namespace Assets.Scripts.Components.Input
{
    public static class InputManagerParser
    {
        public static readonly string InputManagerPath = "ProjectSettings/InputManager.asset";
        public static readonly string InputManagerProperties = "m_Axes";
        public static readonly string AnalogKey = "Analog";
        public static readonly string ButtonKey = "ButtonKey";
        public static readonly string MouseKey = "MouseKey";
        public static readonly string InputManagerRelativeResourcePath = "Input/InputManagerRawInput.txt";
        public static readonly string InputManagerAbsoluteFilePath = Application.dataPath + @"/Resources/" + InputManagerRelativeResourcePath;

        // Can't serialise naked arrays with Unity JSON plugin (boo)
        [System.Serializable]
        private class RawInputContainer
        {
            public RawInputContainer(List<RawInput> inRawInputs)
            {
                RawInputs = inRawInputs;
            }

            public readonly List<RawInput> RawInputs;
        }

        public static void WriteInputManagerToFile()
        {
            var inputAsJson = ConvertInputManagerToJson();

            File.WriteAllText(InputManagerAbsoluteFilePath, inputAsJson);
        }

        public static string ConvertInputManagerToJson()
        {
            var allRawInputs = new RawInputContainer(GetRawInputsFromInputManager());

            var output = JsonUtility.ToJson(allRawInputs);

            Debug.Log("Input manager as JSON:\n" + output);

            return output;
        }

        public static List<RawInput> GetRawInputsFromInputManager()
        {
            var allRawInputs = new List<RawInput>();

            var serialisedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(InputManagerPath)[0]);

            var serialisedProperty = serialisedObject.FindProperty(InputManagerProperties);

            // Get past size property
            serialisedProperty.Next(true);
            serialisedProperty.Next(true);

            while (serialisedProperty.Next(false))
            {
                var axis = serialisedProperty.Copy();
                axis.Next(true);
                if (axis.stringValue.Contains(AnalogKey))
                {
                    allRawInputs.Add(new RawInput(axis.stringValue, EInputType.Analog));
                }
                else if (axis.stringValue.Contains(ButtonKey))
                {
                    allRawInputs.Add(new RawInput(axis.stringValue, EInputType.Button));
                }
                else if (axis.stringValue.Contains(MouseKey))
                {
                    allRawInputs.Add(new RawInput(axis.stringValue, EInputType.Mouse));
                }
                else
                {
                    Debug.Log("Failed to categorise " + axis.stringValue);
                }
            }
            return allRawInputs;
        }

        public static int GetNumberOfInputsRegistered()
        {
            var serialisedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(InputManagerPath)[0]);

            var serialisedProperty = serialisedObject.FindProperty(InputManagerProperties);

            // Get past size property
            serialisedProperty.Next(true);
            serialisedProperty.Next(true);

            return serialisedProperty.intValue;
        }

        public static List<RawInput> ReadInputManagerOutput()
        {
            var text = File.ReadAllText(InputManagerAbsoluteFilePath, Encoding.UTF8);
            var output = JsonUtility.FromJson<RawInputContainer>(text);

            return output.RawInputs;
        }
    }
}
