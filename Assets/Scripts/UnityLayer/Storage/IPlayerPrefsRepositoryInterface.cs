// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.UnityLayer.Storage
{
    public interface IPlayerPrefsRepositoryInterface
    {
        void SetKey<TValueType>(string key, TValueType inValue);

        string GetValueForKey(string key);

        void Save();
        void DeleteAll();
    }
}
