// Copyright Threetee Gang (C) 2017

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

            mockPlayerPrefsRepoInterface.GetValueForKey(Arg.Any<string>()).Returns(EInputKey.FireButton.ToString());

            var defaultTranslatedInputRepo = new DefaultTranslatedInputRepository(mockPlayerPrefsRepoInterface);
            defaultTranslatedInputRepo.RetrieveMappingsForRawInputs(expectedRawInputs);

            foreach (var expectedRawInput in expectedRawInputs)
            {
                mockPlayerPrefsRepoInterface.Received().GetValueForKey(Arg.Is(expectedRawInput.InputName));
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
                mockPlayerPrefsRepoInterface.GetValueForKey(Arg.Any<string>())
                    .Returns(expectedInputKey.ToString());
            }

            var defaultTranslatedInputRepo = new DefaultTranslatedInputRepository(mockPlayerPrefsRepoInterface);
            var actualMappings = defaultTranslatedInputRepo.RetrieveMappingsForRawInputs(expectedRawInputs);

            foreach (var expectedRawInput in expectedRawInputs)
            {
                Assert.IsTrue(ObjectComparisonExtensions.EqualByPublicProperties(actualMappings[expectedRawInput], new TranslatedInput(expectedInputKey, expectedRawInput.InputType)));
            }
        }

        [Test]
        public void DefaultTranslatedInputRepository_RetrieveMappingsForRawInputs_NoMappingsReturnsDefaultMappings()
        {
            var mockPlayerPrefsRepoInterface = Substitute.For<IPlayerPrefsRepositoryInterface>();

            var expectedRawInputs = new List<RawInput>
            {
                new RawInput("Test", EInputType.Button),
                new RawInput("Test2", EInputType.Analog)
            };

            const string nullString = null;

            foreach (var expectedRawInput in expectedRawInputs)
            {
                mockPlayerPrefsRepoInterface.GetValueForKey(Arg.Is(expectedRawInput.InputName))
                    .Returns(nullString);
            }

            var defaultTranslatedInputRepo = new DefaultTranslatedInputRepository(mockPlayerPrefsRepoInterface);
            var actualMappings = defaultTranslatedInputRepo.RetrieveMappingsForRawInputs(expectedRawInputs);

            foreach (var mapping in actualMappings)
            {
                Assert.IsTrue(ObjectComparisonExtensions.EqualByPublicProperties(mapping.Value, defaultTranslatedInputRepo.DefaultMappings[mapping.Key]));
            }
        }

        [Test]
        public void DefaultTranslatedInputRepository_RetrieveMappingsForRawInputs_NoRawInputsReturnsDefaultMappings()
        {
            var mockPlayerPrefsRepoInterface = Substitute.For<IPlayerPrefsRepositoryInterface>();

            var emptyRawInputs = new List<RawInput>();

            var defaultTranslatedInputRepo = new DefaultTranslatedInputRepository(mockPlayerPrefsRepoInterface);
            var actualMappings = defaultTranslatedInputRepo.RetrieveMappingsForRawInputs(emptyRawInputs);

            foreach (var mapping in actualMappings)
            {
                Assert.IsTrue(ObjectComparisonExtensions.EqualByPublicProperties(mapping.Value, defaultTranslatedInputRepo.DefaultMappings[mapping.Key]));
            }
        }

        [Test]
        public void DefaultTranslatedInputRepository_RetrieveMappingsForRawInputs_NullRawInputsReturnsDefaultMappings()
        {
            var mockPlayerPrefsRepoInterface = Substitute.For<IPlayerPrefsRepositoryInterface>();

            List<RawInput> emptyRawInputs = null;

            var defaultTranslatedInputRepo = new DefaultTranslatedInputRepository(mockPlayerPrefsRepoInterface);
            var actualMappings = defaultTranslatedInputRepo.RetrieveMappingsForRawInputs(emptyRawInputs);

            foreach (var mapping in actualMappings)
            {
                Assert.IsTrue(ObjectComparisonExtensions.EqualByPublicProperties(mapping.Value, defaultTranslatedInputRepo.DefaultMappings[mapping.Key]));
            }
        }
    }
}
