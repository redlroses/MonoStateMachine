using System;
using System.Collections.Generic;
using CodeBase.Logic.Rabbit.States;
using CodeBase.MonoStateMachine;

namespace CodeBase.Logic.Rabbit
{
    public class RabbitStateMachine : MonoStateMachine.MonoStateMachine
    {
        protected override void InitTransitions()
        {
            foreach (ITransition transition in GetComponentsInChildren<ITransition>())
            {
                transition.Init(this);
            }
        }

        protected override void SetDefaultState() =>
            ChangeState<RabbitIdleState>();

        protected override Dictionary<Type, IMonoState> GetStates() =>
            new Dictionary<Type, IMonoState>
            {
                [typeof(RabbitIdleState)] = GetComponentInChildren<RabbitIdleState>(),
                [typeof(RabbitMoveState)] = GetComponentInChildren<RabbitMoveState>(),
            };
    }
}