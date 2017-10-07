// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.UnityLayer.GameObjects
{
    public static class DestructionFunctions
    {
        public static void DestroyGameObject(GameObject inGameObject)
        {
            if (Application.isPlaying)
            {
                Object.Destroy(inGameObject);
            }
            else
            {
                Object.DestroyImmediate(inGameObject);
            }
        }
    }
}
