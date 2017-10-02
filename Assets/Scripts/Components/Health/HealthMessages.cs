// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.UnityEvent;

namespace Assets.Scripts.Components.Health
{
    [System.Serializable]
    public class HealthChangedMessage
        : UnityMessagePayload
    {
        public HealthChangedMessage(int inNewHealth)
        {
            NewHealth = inNewHealth;
        }

        public readonly int NewHealth;
    }
}
