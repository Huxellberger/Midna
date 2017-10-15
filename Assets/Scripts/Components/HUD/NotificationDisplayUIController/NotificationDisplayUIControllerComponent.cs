// Copyright Threetee Gang (C) 2017

using Assets.Scripts.Components.ActionStateMachine.States.Dead;
using Assets.Scripts.Components.UnityEvent;
using Text = UnityEngine.UI.Text;

namespace Assets.Scripts.Components.HUD.NotificationDisplayUIController
{
    public class NotificationDisplayUIControllerComponent 
        : HUDElementComponent
    {
        public string DeathMessage = "You Died Loser";

        private UnityMessageEventHandle<EnteredDeadActionStateMessage> EnteredDeadActionStateHandle { get; set; }
        private UnityMessageEventHandle<LeftDeadActionStateMessage> LeftDeadActionStateHandle { get; set; }
        private Text TextComponent { get; set; }

        protected void Start()
        {
            TextComponent = GetComponent<Text>();
        }

        protected override void OnMessageInterfaceRemoved()
        {
            MessageEventInterface.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(LeftDeadActionStateHandle);
            MessageEventInterface.GetUnityMessageEventDispatcher().UnregisterForMessageEvent(EnteredDeadActionStateHandle);
        }

        protected override void OnMessageInterfaceSet()
        {
            EnteredDeadActionStateHandle = MessageEventInterface.GetUnityMessageEventDispatcher()
                .RegisterForMessageEvent<EnteredDeadActionStateMessage>(OnEnteredDeadActionState);

            LeftDeadActionStateHandle = MessageEventInterface.GetUnityMessageEventDispatcher()
                .RegisterForMessageEvent<LeftDeadActionStateMessage>(OnLeftDeadActionState);
        }

        private void OnEnteredDeadActionState(EnteredDeadActionStateMessage inMessage)
        {
            TextComponent.text = DeathMessage;
        }

        private void OnLeftDeadActionState(LeftDeadActionStateMessage inMessage)
        {
            TextComponent.text = "";
        }
    }
}
