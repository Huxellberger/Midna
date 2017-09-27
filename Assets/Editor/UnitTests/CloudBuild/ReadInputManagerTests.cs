// Copyright Threetee Gang (C) 2017

using Assets.Editor.CloudBuild.BuildSteps;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.CloudBuild
{
    [TestFixture]
    public class ReadInputManagerTestFixture
    {
        [Test]
        public void GetRawInputsFromInputManager_ParsesFileSuccessfully()
        {
            Assert.Greater(ReadInputManager.GetRawInputsFromInputManager().Count, 0);
        }
    }
}
