// Copyright Threetee Gang (C) 2017

using System.Collections.Generic;

namespace Assets.Scripts.Components.Input
{
    public class RawInputEqualityComparer
        : IEqualityComparer<RawInput>
    {
        public bool Equals(RawInput x, RawInput y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.InputName.Equals(y.InputName) && x.InputType == y.InputType;
        }

        public int GetHashCode(RawInput obj)
        {
            return obj.InputName.GetHashCode() + obj.InputType.GetHashCode();
        }
    }
}
