using System;
using System.Collections.Generic;
using Main.Scripts.MovableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Main.Scripts
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private MovingObjectBase[] _movingObjects;
        [SerializeField] private BoxCollider2D _spawnAreaBox;

        public void SpawnNewObject(InputAction.CallbackContext obj)
        {
            var spawnPositon = GetRandomPointInSpawnerBoxCollider();

            var prefabIndex = Random.Range(0, _movingObjects.Length);
            Instantiate(_movingObjects[prefabIndex], spawnPositon, Quaternion.identity);
        }
        
        private Vector2 GetRandomPointInSpawnerBoxCollider()
        {
            Vector2 min = _spawnAreaBox.bounds.min;
            Vector2 max = _spawnAreaBox.bounds.max;
            
            return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        }
    }
}
