using Game.Inputs;
using UnityEngine;

namespace Game.FirstPerson
{
    [SelectionBase]
    [DisallowMultipleComponent]
    public class FirstPersonPlayerController : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField] private FirstPersonCharacter character;
        
        [Header("Camera")]
        [SerializeField] private Transform playerCamera;
        [SerializeField] private Vector2 sensitivityMultiplier = new(0.5f, 0.5f);
        [SerializeField] private Vector2 pitchMaxAngles = new(-80f, 80f);

        private Vector3 viewEuler;

        private void Start()
        {
#if DEBUG
            if (character == null)
            {
                Debug.LogWarning($"{nameof(FirstPersonCharacter)} not set. Skipping character initialization");
                
                return;
            }
#endif

            character.Initialize();

            var cameraTargetTransform = character.CameraTargetTransform;
            
            // Snap camera to the first person camera position.
            playerCamera.SetPositionAndRotation(cameraTargetTransform.position, cameraTargetTransform.rotation);
        }

        private void Update()
        {
#if DEBUG
            if (character == null)
            {
                return;
            }
#endif
            
            var playerActions = InputManager.instance.inputSystemActions.Player;
            
            Vector2 lookInput = playerActions.Look.ReadValue<Vector2>();
            lookInput *= sensitivityMultiplier;

            viewEuler += new Vector3(-lookInput.y, lookInput.x);
            viewEuler.x = Mathf.Clamp(viewEuler.x, pitchMaxAngles.x, pitchMaxAngles.y);
            
            // playerCamera.eulerAngles = viewEuler;
            playerCamera.rotation = Quaternion.Euler(viewEuler);
            
            var characterInput = new FirstPersonCharacterInput
            {
                Yaw = viewEuler.y,
                Rotation = playerCamera.rotation,
                Move = playerActions.Move.ReadValue<Vector2>(),
            };
            character.UpdateInput(ref characterInput);
        }

        private void LateUpdate()
        {
#if DEBUG
            if (character == null || character.CameraTargetTransform == null)
            {
                return;
            }
#endif
            
            playerCamera.position = character.CameraTargetTransform.position;
        }
    }
}