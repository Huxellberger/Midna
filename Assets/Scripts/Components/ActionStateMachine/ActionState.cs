﻿// Copyright Threetee Gang (C) 2017

namespace Midna.Components.ActionStateMachine
{
    public abstract class ActionState
    {
        protected ActionState(EActionStateId inActionStateId)
        {
            actionStateId = inActionStateId;
        }

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

        public EActionStateId actionStateId { get; private set; }
    }
}
