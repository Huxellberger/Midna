using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Midna.Editor.UnitTests
{
    [TestFixture]
    public class DefaultTests
    {
        [Test]
        public void GivenFailingTest_BuildGoesRed()
        {
            //Given
            var gameObject = new GameObject();

            //When
            //Try to rename the GameObject
            var newGameObjectName = "My game object";
            gameObject.name = newGameObjectName;

            //Then
            //The object has a new name
            Assert.AreEqual(newGameObjectName, gameObject.name);
        }
    }
}
