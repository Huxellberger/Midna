// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR
using Assets.Scripts.Components.UnityEvent;
using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Test.Integration.Visual
{
    public class VisualTestComponent 
        : IntegrationTestComponent
    {
        public string TestName;

        private static string BeforePath = "Test/VisualTests/Before/";
        private static string AfterPath = "Test/VisualTests/After/";

        private UnityMessageEventHandle<VisualTestAssertMessage> VisualTestAssertHandle { get; set; }
        private IUnityMessageEventInterface UnityMessageEventInterface { get; set; }

        protected override void RunTestImpl()
        {
            UnityMessageEventInterface = gameObject.GetComponent<IUnityMessageEventInterface>();
            RegisterForAssertMessage();
        }

        private void RegisterForAssertMessage()
        {
            if (UnityMessageEventInterface != null)
            {
                VisualTestAssertHandle = UnityMessageEventInterface.GetUnityMessageEventDispatcher()
                    .RegisterForMessageEvent<VisualTestAssertMessage>(OnVisualTestAssertMessage);
            }
        }

        private void UnregisterForAssertMessage()
        {
            if (VisualTestAssertHandle.IsRegistered())
            {
                if (UnityMessageEventInterface != null)
                {
                    UnityMessageEventInterface.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(VisualTestAssertHandle);
                }
            }
        }

        private void OnVisualTestAssertMessage(VisualTestAssertMessage inMessage)
        {
            var applicationPath = Application.dataPath + @"/" + AfterPath + TestName + ".png";

            Application.CaptureScreenshot(applicationPath);
            if (ImagesAreEqual())
            {
                Passed = true;
            }

            UnregisterForAssertMessage();
        }

        private bool ImagesAreEqual()
        {
            var originalAssetPath = "Assets/" + BeforePath + TestName + ".png";
            var generatedAssetPath = "Assets/" + AfterPath + TestName + ".png";

            var originalImporter = GetTextureImporterForPath(originalAssetPath);
            AssetDatabase.ImportAsset(originalAssetPath);

            var generatedImporter = GetTextureImporterForPath(generatedAssetPath);
            AssetDatabase.ImportAsset(generatedAssetPath);

            AssetDatabase.Refresh();

            var originalImage = AssetDatabase.LoadAssetAtPath<Texture2D>(originalAssetPath);
            var generatedImage = AssetDatabase.LoadAssetAtPath<Texture2D>(generatedAssetPath);

            int pixelCount = originalImage.GetPixels().Length;

            var originalPixels = originalImage.GetPixels();
            var generatedPixels = generatedImage.GetPixels();

            for (int index = 0; index < pixelCount; index++)
            {
                if (originalPixels[index] != generatedPixels[index])
                {
                    return false;
                }
            }

            return true;
        }

        private TextureImporter GetTextureImporterForPath(string path)
        {
            var importer = AssetImporter.GetAtPath(path) as TextureImporter;
            importer.textureType = TextureImporterType.Default;
            importer.isReadable = true;

            return importer;
        }
    }
}
#endif // UNITY_EDITOR
