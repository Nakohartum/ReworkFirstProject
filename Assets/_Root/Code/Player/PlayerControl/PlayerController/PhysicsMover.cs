using UnityEngine;

namespace _Root.Code.Player.PlayerControl
{
    public class PhysicsMover
    {
        private Rigidbody _rigidbody;
        private float _speed;
        private Camera _camera;

        public PhysicsMover(Rigidbody rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
            _camera = Camera.main;
        }

        public void Move(Vector3 moveDirection, Vector3 lookDirection)
        {
            lookDirection.y = 0;
            var rotationOfMoveDirection = Quaternion.LookRotation(lookDirection);
            moveDirection = rotationOfMoveDirection * moveDirection * _speed;
            _rigidbody.MovePosition(_rigidbody.position + moveDirection);
        }
    }
}