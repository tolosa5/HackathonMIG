using Game.Interaction;
using UnityEngine;

namespace Game.Interaction
{
    public interface IGrabbable : IInteractable
    {
        public void Grab(Transform grabPoint);
    }
}
