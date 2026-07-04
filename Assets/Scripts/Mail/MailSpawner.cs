using Game.EventSystem.Channels;
using Game.Interaction;
using UnityEngine;
using Void = Game.EventSystem.Channels.Void;

namespace Game.Mail
{
    public class MailSpawner : MonoBehaviour
    {
        [SerializeField] private float[] spawnTimeStamps;
        [SerializeField] private InspectableData[] letterDatas;
        bool isTimerActive = false;
        private int currentLetter = 0;
        
        [SerializeField] private GameObject mailPrefab;

        [SerializeField] private VoidEventChannel onGameStartEvent;
        [SerializeField] private VoidEventChannel onEndGameEvent;

        private void Awake()
        {
            //onGameStartEvent.Register(StartSpawn(Void void));
        }

        private void StartSpawn()
        {
            Spawn();
            isTimerActive = true;
        }

        private void Update()
        {
            if (!isTimerActive)
                return;
            
            float currentTime = Time.deltaTime;
            if (currentLetter >= spawnTimeStamps.Length)
            {
                isTimerActive = false;
                currentTime = 0f;
                Debug.Log("All letters spawned");
                onEndGameEvent.Notify();
                return;
            }
            if (currentTime >= spawnTimeStamps[currentLetter] && isTimerActive)
            {
                Spawn();
                currentLetter++;
            }
        }

        private void Spawn()
        {
            GameObject spawnedMail = Instantiate(mailPrefab, transform.position, Quaternion.identity);
            if (spawnedMail.TryGetComponent(out Letter mail))
            {
                mail.SetData(letterDatas[currentLetter]);
            }
        }
    }
}
