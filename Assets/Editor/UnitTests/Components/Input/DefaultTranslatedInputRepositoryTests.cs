﻿// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;
using NUnit.Framework;
using Assets.Editor.UnitTests.Helpers;
using Assets.Scripts.Components.Input;
using Assets.Scripts.UnityLayer.Storage;
using NSubstitute;

namespace Assets.Editor.UnitTests.Components.Input
{
    [TestFixture]
    public class DefaultTranslatedInputRepositoryTestFixture {

        [Test]
        public void DefaultTranslatedInputRepository_RetrieveMappingsForRawInputs_UsesInRawInputs()
        {
            var mockPlayerPrefsRepoInterface = Substitute.For<IPlayerPrefsRepositoryInterface>();
            var expectedRawInputs = new List<RawInput>
            {
                new RawInput("Test", EInputType.Button),
                new RawInput("Test2", EInputType.Analog)
            };

            var defaultTranslatedInputRepo = new DefaultTranslatedInputRepository(mockPlayerPrefsRepoInterface);
            defaultTranslatedInputRepo.RetrieveMappingsForRawInputs(expectedRawInputs);

            foreach (var expectedRawInput in expectedRawInputs)
            {
                mockPlayerPrefsRepoInterface.Received().GetValueForKey<EInputKey>(Arg.Is(expectedRawInput.InputName));
            }
        }

        [Test]
        public void DefaultTranslatedInputRepository_RetrieveMappingsForRawInputs_ReturnsExpectedMappings()
        {
            var mockPlayerPrefsRepoInterface = Substitute.For<IPlayerPrefsRepositoryInterface>();

            const EInputKey expectedInputKey = EInputKey.FireButton;

            var expectedRawInputs = new List<RawInput>
            {
                new RawInput("Test", EInputType.Button),
                new RawInput("Test2", EInputType.Analog)
            };

            foreach (var expectedRawInput in expectedRawInputs)
            {
                mockPlayerPrefsRepoInterface.GetValueForKey<EInputKey>(Arg.Is(expectedRawInput.InputName))
                    .Returns(expectedInputKey);
            }
            

            var defaultTranslatedInputRepo = new DefaultTranslatedInputRepository(mockPlayerPrefsRepoInterface);
            var actualMappings = defaultTranslatedInputRepo.RetrieveMappingsForRawInputs(expectedRawInputs);

            foreach (var expectedRawInput in expectedRawInputs)
            {
                Assert.IsTrue(ObjectComparisonExtensions.EqualByPublicProperties(actualMappings[expectedRawInput], new TranslatedInput(expectedInputKey, expectedRawInput.InputType)));
            }
        }
    }
}
