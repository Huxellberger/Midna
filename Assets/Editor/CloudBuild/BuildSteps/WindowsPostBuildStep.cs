// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using UnityEngine;

namespace Assets.Editor.CloudBuild.BuildSteps
{
    public static class WindowsPostBuildStep
    {
        public static void RunWindowsPostBuildStep()
        {
            Debug.Log("Post build begun");

            InputManagerParser.WriteInputManagerToFile();

            // Do a check to make sure we haven't broken the mapping to the default inputs

        }
    }
}
