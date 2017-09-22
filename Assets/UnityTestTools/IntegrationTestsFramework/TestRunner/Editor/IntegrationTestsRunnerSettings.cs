using Assets.UnityTestTools.Common.Editor;

namespace Assets.UnityTestTools.IntegrationTestsFramework.TestRunner.Editor
{
    public class IntegrationTestsRunnerSettings : ProjectSettingsBase
    {
        public bool blockUIWhenRunning = true;
        public bool pauseOnTestFailure;
        
        public void ToggleBlockUIWhenRunning ()
        {
            blockUIWhenRunning = !blockUIWhenRunning;
            Save ();
        }
        
        public void TogglePauseOnTestFailure()
        {
            pauseOnTestFailure = !pauseOnTestFailure;
            Save ();
        }
    }
}
