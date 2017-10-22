// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

using Assets.Scripts.Core;
using NUnit.Framework;

namespace Assets.Editor.UnitTests.Core
{
    [TestFixture]
    public class EnumExtensionsTestFixture
    {
        private enum ETestEnumExtensions
        {
            ValueA,
            ValueB
        }

        [Test]
        public void TryParse_Fails_ReturnsUnsetOptional()
        {
           Assert.IsFalse(EnumExtensions.TryParse<ETestEnumExtensions>(ETestEnumExtensions.ValueA + "Garbage").IsSet());
        }

        [Test]
        public void TryParse_Succeeds_ReturnsSetOptional()
        {
            Assert.IsTrue(EnumExtensions.TryParse<ETestEnumExtensions>(ETestEnumExtensions.ValueA.ToString()).IsSet());
        }
    }
}

#endif
