using System;
using UnityEngine;

namespace Game.Mail
{
    public class MailBoxTrigger : MonoBehaviour
    {
        [SerializeField] private MailType mailBoxType;
        
        public Action onCorrectMailEvent;
        public Action onWrongMailEvent;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Letter mail))
                return;

            if (mail.Data.correctMailType == mailBoxType)
                CorrectMail();
            else
                WrongMail();
        }

        private void CorrectMail()
        {
            Debug.Log("Correct mail");
            onCorrectMailEvent?.Invoke();
        }

        private void WrongMail()
        {
            Debug.Log("Wrong mail");
            onWrongMailEvent?.Invoke();
        }
    }
}
