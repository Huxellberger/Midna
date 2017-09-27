// Copyright Threetee Gang (C) 2017

using System;
using System.Linq;
using Assets.Scripts.Attributes;
using Castle.Core.Internal;

namespace Assets.Editor.Inspector
{
    public abstract class UnityNakedEditor
        : UnityEditor.Editor
    {
        void OnInspectorGui()
        {
            var type = target.GetType();

            var fields = type.GetFields().Where(field => Attribute.IsDefined(field, typeof(UnityNakedAttribute)));

            foreach (var field in fields)
            {
                switch (field.GetAttribute<UnityNakedAttribute>().AttributeType)
                {
                    case EUnityNakedAttributeType.StringType:
                        break;
                    case EUnityNakedAttributeType.IntType:
                        break;
                    case EUnityNakedAttributeType.FloatType:
                        break;
                    case EUnityNakedAttributeType.InterfaceType:
                        break;
                    case EUnityNakedAttributeType.DecomposableObjectType:
                        break;
                    case EUnityNakedAttributeType.ArrayType:
                        break;
                    case EUnityNakedAttributeType.MapType:
                        break;
                }
            }
        }
       
    }
}
