// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.Input
{
    public struct PlayerInput
    {
        private readonly string _inputName;
        private readonly EInputType _inputType;

        public PlayerInput(string inInputName, EInputType inInputType)
        {
            _inputName = inInputName;
            _inputType = inInputType;
        }

        public string InputName { get { return _inputName; }  }
        public EInputType InputType { get { return _inputType; } }
    }
}
