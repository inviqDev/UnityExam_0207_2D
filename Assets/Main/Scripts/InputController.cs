using UnityEngine;

namespace Main.Scripts
{
    public class InputController : MonoBehaviour
    {
        private InputActions _inputActions;

        private void OnEnable()
        {
            _inputActions ??= new InputActions();
            _inputActions.Gameplay.Spawn.performed += ObjectSpawner.Instance.SpawnNewObject;
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            if (_inputActions == null) return;
            
            _inputActions.Gameplay.Spawn.performed -= ObjectSpawner.Instance.SpawnNewObject;
            _inputActions?.Disable();
        }
    }
}
