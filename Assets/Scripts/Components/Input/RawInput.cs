// Copyright Threetee Gang (C) 2017

namespace Assets.Scripts.Components.Input
{
    [System.Serializable]
    public class RawInput
        : PlayerInput
    {
        private readonly string _inputName;

        public RawInput(string inInputName, EInputType inInputType)
            : base(inInputType)
        {
            _inputName = inInputName;
        }

        public string InputName { get { return _inputName; } }
    }
}
