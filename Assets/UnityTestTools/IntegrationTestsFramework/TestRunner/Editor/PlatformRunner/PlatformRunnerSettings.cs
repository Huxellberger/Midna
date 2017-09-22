using Assets.UnityTestTools.Common.Editor;

namespace Assets.UnityTestTools.IntegrationTestsFramework.TestRunner.Editor.PlatformRunner
{
    public class PlatformRunnerSettings : ProjectSettingsBase
    {
        public string resultsPath;
        public bool sendResultsOverNetwork = true;
        public int port = 0;
    }
}
