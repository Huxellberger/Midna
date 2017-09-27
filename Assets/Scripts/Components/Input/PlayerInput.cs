// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.Input
{
    [System.Serializable]
    public class PlayerInput
    {
        private readonly EInputType _inputType;

        public PlayerInput(EInputType inInputType)
        {
            _inputType = inInputType;
        }

        public EInputType InputType { get { return _inputType; } }
    }
}
