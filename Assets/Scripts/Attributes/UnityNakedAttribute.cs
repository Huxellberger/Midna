// Copyright Threetee Gang (C) 2017

using System;

namespace Assets.Scripts.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class UnityNakedAttribute
        : Attribute
    {
        public readonly EUnityNakedAttributeType AttributeType;

        public UnityNakedAttribute(EUnityNakedAttributeType inNakedAttributeType)
        {
            AttributeType = inNakedAttributeType;
        }
    }
}
