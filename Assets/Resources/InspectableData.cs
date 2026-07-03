using Game.Mail;
using UnityEngine;

namespace Game.Interaction
{
    [CreateAssetMenu(fileName = "InspectableData", menuName = "Scriptable Objects/InspectableData")]
    public class InspectableData : ScriptableObject
    {
        [SerializeField] public string ItemName;
        
        [TextArea]
        [SerializeField] public string ItemContent;
        [SerializeField] public MailType correctMailType;
    }
}
