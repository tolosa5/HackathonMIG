using UnityEngine;

namespace Game.EventSystem.Channels
{
    public readonly struct Void
    {
    }

    [CreateAssetMenu(menuName = "Events/Channels/Void Channel")]
    public class VoidEventChannel : EventChannel<Void>
    {
    }
}