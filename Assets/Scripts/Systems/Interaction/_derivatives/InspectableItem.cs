using System;
using UnityEngine;

namespace Game.Interaction
{
    public class InspectableItem : BaseInteractable
    {
        [SerializeField] private InspectableData data;
        public InspectableData Data => data;
        
        public Action<InspectableData> onInspectItemUIEvent;
        
        public override void Interact(Transform interactor)
        {
            onInspectItemUIEvent?.Invoke(data);
        }

        public void SetData(InspectableData data) { this.data = data; }
    }
}
