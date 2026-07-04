using Game.Mail;
using TMPro;
using UnityEngine;

namespace Game.PitchVideo
{
    public class PitchVideo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI emailDroppedText;
        
        private MailBoxTrigger[] mailBoxTriggers;

        private void Awake()
        {
            mailBoxTriggers = FindObjectsByType<MailBoxTrigger>();
            
            emailDroppedText.gameObject.SetActive(false);
        }

        private void Start()
        {
            foreach (var mailBox in mailBoxTriggers)
            {
                mailBox.onCorrectMailEvent += OnCorrectMailEvent;
                mailBox.onWrongMailEvent += OnWrongMailEvent;
            }
        }

        private void OnDestroy()
        {
            foreach (var mailBox in mailBoxTriggers)
            {
                mailBox.onCorrectMailEvent -= OnCorrectMailEvent;
                mailBox.onWrongMailEvent += OnWrongMailEvent;
            }
        }

        private void OnCorrectMailEvent()
        {
            emailDroppedText.gameObject.SetActive(true);
            emailDroppedText.text = "MAIL CORRECTO";
        }

        private void OnWrongMailEvent()
        {
            emailDroppedText.gameObject.SetActive(true);
            emailDroppedText.text = "MAIL INCORRECTO";
        }
    }
}