using System;
using Game.EventSystem.Channels;
using UnityEngine;

namespace Game.Interaction
{
    public class InspectableItem : BaseInteractable
    {
        [SerializeField] private InspectableData data;
        public InspectableData Data => data;
        
        [SerializeField] private VoidEventChannel onInspectItemUIEvent;
        
        public override void Interact(Transform interactor)
        {
            //onInspectItemUIEvent?.Notify(data);
        }

        public void SetData(InspectableData data) { this.data = data; }
    }
}
