using UnityEngine;
using Random = UnityEngine.Random;

namespace Main.Scripts.MovableObjects
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ColorChangeObject : MovingObjectBase
    {
        private Color[] _colors;
        
        private SpriteRenderer _spriteRenderer;
        private int _currentIndex;
        
        private void Awake()
        {
            _colors = CreateColorsArray();
            
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentIndex = 0;
            
            _spriteRenderer.color = _colors[_currentIndex];
        }

        private Color[] CreateColorsArray()
        {
            return new[]
            {
                Color.green,
                Color.magenta,
                Color.red,
                Color.yellow,
            };
        }

        protected override void ChangeOnBounce()
        {
            ++_currentIndex;
            if (_currentIndex >= _colors.Length)
            {
                _currentIndex = 0;
            }
            
            _spriteRenderer.color = _colors[_currentIndex];
        }
    }
}
