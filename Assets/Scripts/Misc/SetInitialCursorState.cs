using UnityEngine;

namespace Game.Misc
{
    [DisallowMultipleComponent]
    public class SetInitialCursorState : MonoBehaviour
    {
        [SerializeField] private CursorLockMode lockMode = CursorLockMode.Locked;
        [SerializeField] private bool visible = true;
        
        private void Start()
        {
            Cursor.lockState = lockMode;
            Cursor.visible = visible;
        }
    }
}