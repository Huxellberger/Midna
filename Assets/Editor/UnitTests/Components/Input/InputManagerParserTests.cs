// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.Input;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Components.Input
{
    [TestFixture]
    public class InputManagerParserTestFixture
    {
        [Test]
        public void GetRawInputsFromInputManager_ParsesFileSuccessfully()
        {
            Assert.AreEqual(InputManagerParser.GetNumberOfInputsRegistered(), InputManagerParser.GetRawInputsFromInputManager().Count);
        }

        [Test]
        public void SaveRawInputsToFile()
        {
            InputManagerParser.WriteInputManagerToFile();
        }
    }
}
