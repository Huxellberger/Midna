// Copyright Threetee Gang (C) 2017

#if UNITY_EDITOR

namespace Assets.Scripts.Test.TestableMonobehaviour
{
    public interface ITestableMonobehaviour
    {
        void PrepareForTest(params object[] parameters);
    }
}

#endif
