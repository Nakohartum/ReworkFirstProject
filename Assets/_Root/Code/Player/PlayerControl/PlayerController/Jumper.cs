using UnityEngine;

namespace _Root.Code.Player.PlayerControl
{
    public class Jumper
    {
        private Rigidbody _rigidbody;
        private Ray _ray;

        public Jumper(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Jump(Transform jumper, float jumpPower)
        {
            var position = jumper.position;
            var offset = new Vector3(position.x, position.y + 0.5f, position.z);
            _ray = new Ray(offset, Vector3.down);
            if (Physics.Raycast(_ray, 1.0f))
            {
                _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}