using System;
using UnityEngine;

namespace Main.Scripts
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private ObjectSpawner _objectSpawner;
        private InputActions _inputActions;

        private void OnEnable()
        {
            _inputActions ??= new InputActions();
            _inputActions.Gameplay.Spawn.performed += _objectSpawner.SpawnNewObject;
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            if (_inputActions == null) return;
            
            _inputActions.Gameplay.Spawn.performed += _objectSpawner.SpawnNewObject;
            _inputActions?.Disable();
        }
    }
}
