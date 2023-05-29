using UnityEngine;
namespace CodeBase.Logic.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _currentVelocity;
        private Vector3 _moveDirection;
        protected Rigidbody Rigidbody => _rigidbody;

        private void Awake() =>
            _rigidbody ??= GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        protected abstract Vector3 GetMoveDirection();
        protected abstract Quaternion GetLookRotation();

        private void Move()
        {
            Vector3 moveDirection = GetMoveDirection();
            Vector3 velocity = moveDirection * _speed;
            _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);
        }

        private void Rotate()
        {
            Quaternion lookRotation = GetLookRotation();
            Quaternion targetRotation = Quaternion.Slerp(_rigidbody.rotation, lookRotation, _rotateSpeed * Time.fixedDeltaTime);

            _rigidbody.MoveRotation(targetRotation);
        }
    }
}