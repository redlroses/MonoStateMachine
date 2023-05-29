using CodeBase.MonoStateMachine;
using UnityEngine;

namespace CodeBase.Logic.Rabbit.States
{
    public class RabbitMoveState : State
    {
        [SerializeField] private RabbitAnimator _animator;
        [SerializeField] private RabbitMover _mover;
        [SerializeField] private BoundsPosition _bounds;

        private void OnEnable()
        {
            _animator.SetMove();
            Vector3 randomPositionInBounds = _bounds.GetRandomBoundsPosition();
            _mover.SetDestination(randomPositionInBounds);
            _mover.enabled = true;
        }

        private void OnDisable() =>
            _mover.enabled = false;
    }
}