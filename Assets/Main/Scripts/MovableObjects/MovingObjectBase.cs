using UnityEngine;
using Random = UnityEngine.Random;

namespace Main.Scripts.MovableObjects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class MovingObjectBase : MonoBehaviour, IMovable
    {
        [SerializeField] protected float _moveSpeed = 12f;

        protected Rigidbody2D _objectRb;
        protected Vector2 _moveDirection;

        private readonly int _maxBouncesAmount = 2;
        private int _bouncesAmount;

        private void OnEnable()
        {
            StartMoving();
        }
        
        public void StartMoving()
        {
            _objectRb ??= GetComponent<Rigidbody2D>();
            
            _moveDirection = Random.insideUnitCircle.normalized;
            _objectRb.linearVelocity = _moveDirection * _moveSpeed;
        }

        protected abstract void ChangeOnBounce();

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer != LayerMask.NameToLayer("ChangingLayer")) return;

            var normal = collision.contacts[0].normal;
            _moveDirection = Vector2.Reflect(_moveDirection, normal);
            _objectRb.linearVelocity = _moveDirection * _moveSpeed;

            if (++_bouncesAmount > _maxBouncesAmount)
            {
                Destroy(gameObject);

                // _bouncesAmount = 0;
                // gameObject.SetActive(false);
            }

            ChangeOnBounce();
        }
    }
}