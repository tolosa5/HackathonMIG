using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.FirstPerson
{
    [DisallowMultipleComponent]
    public class FirstPersonPlayerController : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField] private FirstPersonCharacter character;
        
        [Header("Camera")]
        [SerializeField] private Transform cameraRoot;
        [SerializeField] private Transform cameraTarget;
        [SerializeField, Range(0f, 1f)] private Vector2 sensitivityMultiplier = new(0.5f, 0.5f);

        private Vector3 viewEuler;
        
        // TODO: Eliminar esto. Temporal para pruebas.
        public InputActionReference LookInput;
        public InputActionReference MoveInput;
        
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
            
            // Snap camera to the first person camera position.
            cameraRoot.SetPositionAndRotation(cameraTarget.position, cameraTarget.rotation);
        }

        private void Update()
        {
            Vector2 lookInput = LookInput.action.ReadValue<Vector2>();
            
            viewEuler += new Vector3(-lookInput.y, lookInput.x);

            cameraRoot.eulerAngles = viewEuler;
        }

        private void LateUpdate()
        {
            cameraRoot.position = cameraTarget.position;
        }
    }
}