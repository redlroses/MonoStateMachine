using CodeBase.MonoStateMachine;
using UnityEngine;

namespace CodeBase.Logic.Rabbit.States
{
    public class RabbitIdleState : State
    {
        [SerializeField] private RabbitAnimator _animator;

        private void OnEnable() =>
            _animator.SetIdle();
    }
}