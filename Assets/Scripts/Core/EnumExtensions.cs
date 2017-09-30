// Copyright Threetee Gang (C) 2017

using System;

namespace Assets.Scripts.Core
{
    public static class EnumExtensions
    {
        public static Optional<TEnumType>TryParse<TEnumType>(string inputString)
        {
            try
            {
                return new Optional<TEnumType>( (TEnumType)Enum.Parse(typeof(TEnumType), inputString));
            }
            catch (Exception e)
            {
                return new Optional<TEnumType>();
            }
        }
    }
}
