using System;
using Game.Interaction;
using UnityEngine;

namespace Game.Mail
{
    public class Letter : InspectableItem
    {
        private MailType mailType = MailType.Spain;
        public MailType MailType => mailType;
        
        [Tooltip("0 es España, 1 es Argentina")]
        [SerializeField] private GameObject[] stamps;

        public Action<MailType> onStampLetterEvent;
        
        public void BeStamped(MailType stamp)
        {
            mailType = stamp;
            foreach (var aux in stamps)
            {
                aux.SetActive(false);
            }
            stamps[(int)stamp].SetActive(true);
            onStampLetterEvent?.Invoke(stamp);
        }
    }
}
