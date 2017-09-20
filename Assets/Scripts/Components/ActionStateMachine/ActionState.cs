// Copyright Threetee Gang (C) 2017

namespace Midna.Components.ActionStateMachine
{
    public abstract class ActionState
    {
        public void Start()
        {
            OnStart();
        }

        public void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
        }

        public void End()
        {
            OnEnd();
        }

        protected abstract void OnStart();
        protected abstract void OnUpdate(float deltaTime);
        protected abstract void OnEnd();
    }
}
