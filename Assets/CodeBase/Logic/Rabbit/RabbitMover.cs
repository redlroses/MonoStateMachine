using CodeBase.Logic.Movement;
using UnityEngine;

namespace CodeBase.Logic.Rabbit
{
    public class RabbitMover : Mover
    {
        private Vector3 _destinationPoint;

        public Vector3 DestinationPoint => _destinationPoint;

        public void SetDestination(Vector3 position) =>
            _destinationPoint = new Vector3(position.x, Rigidbody.position.y, position.z);

        protected override Vector3 GetMoveDirection() =>
            (DestinationPoint - Rigidbody.position).normalized;

        protected override Quaternion GetLookRotation() =>
            Quaternion.LookRotation(new Vector3(Rigidbody.velocity.x, 0, Rigidbody.velocity.z));
    }
}