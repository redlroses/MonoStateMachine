using CodeBase.Logic.Rabbit.States;
using CodeBase.MonoStateMachine;
using UnityEngine;

namespace CodeBase.Logic.Rabbit.Transitions
{
    public sealed class IdleToMoveTransition : Transition
    {
        [SerializeField] private Vector2 _transitionDelay;

        private float _randomTransitionDelay;
        private float _elapsedTime;

        private void OnEnable()
        {
            _randomTransitionDelay = Random.Range(_transitionDelay.x, _transitionDelay.y);
            _elapsedTime = 0;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _randomTransitionDelay)
            {
                StateMachine.ChangeState<RabbitMoveState>();
            }
        }
    }
}