using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] 
        protected int _speed;
        [SerializeField]
        protected int _targetLocationOffset = 1;
        //TODO: Remove SerializeField
        [SerializeField]
        protected Vector3 _direction;
        //TODO: Remove SerializeField
        [SerializeField]
        protected Vector3 _targetPosition;

        private bool _isMoving;

    #region Accessors

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void SetSpeed(int speed)
        {
            _speed = speed;
        }

    #endregion

        private void Update()
        {
            if (!_isMoving)
            {
                return;
            }
            else if (_direction == Vector3.zero)
            {
                Debug.LogErrorFormat("[CharacterMovement]: Tried to move but direction is zero for {0}", gameObject.name);
                return;
            }

            // if (Vector3.Distance(transform.position, _targetPosition) < _targetLocationOffset)
            // {
            //     StopMovement();
            //     return;
            // }

            Move(Time.deltaTime);
        }

      
        public void StopMovement()
        {
            _direction = Vector3.zero;
            _targetPosition = default;
            _isMoving = false;
        }

        public void SetTarget(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
            _direction = (targetPosition - transform.position).normalized;
        }

        public void StartMovement()
        {
            _isMoving = true;
        }

        private void Move(float deltaTime)
        {
            transform.position += _direction * _speed * deltaTime;
        }
    }
}
