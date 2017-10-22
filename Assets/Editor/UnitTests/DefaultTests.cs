// Copyright Threetee Gang (C) 2017

using NUnit.Framework;
using UnityEngine;

namespace Assets.Editor.UnitTests
{
    [TestFixture]
    public class DefaultTests
    {
        [Test]
        public void DefaultTest()
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
