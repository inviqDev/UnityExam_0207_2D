using UnityEngine;

namespace Main.Scripts.MovableObjects
{
    public class SizeChangeObject : MovingObjectBase
    {
        private readonly float _minSize = 2.0f;
        private readonly float _maxSize = 4.0f;
        
        protected override void ChangeOnBounce()
        {
            transform.localScale = Vector2.one * Random.Range(_minSize, _maxSize);
        }
    }
}
