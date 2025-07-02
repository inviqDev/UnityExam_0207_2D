using UnityEngine;

namespace Main.Scripts.MovableObjects
{
    public class ShapeChangeObject : MovingObjectBase
    {
        [SerializeField] private Sprite[] _shapes;
        
        private SpriteRenderer _spriteRenderer;
        private int _currentIndex;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentIndex = 0;
        }
        
        protected override void ChangeOnBounce()
        {
            ++_currentIndex;
            if (_currentIndex >= _shapes.Length)
            {
                _currentIndex = 0;
            }
            
            _spriteRenderer.sprite = _shapes[_currentIndex];
        }
    }
}
