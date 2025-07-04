using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset = new(0, 180, 0);
        //[SerializeField] private float _max = 0.3f;
        [SerializeField] private float _activityDistance = 64f;

        private Transform _target;
        private Vector3 _initialForward;

        private void Awake()
        {
            SetTarget(Camera.main.transform);
        }

        private void Start()
        {
            _initialForward = transform.eulerAngles.normalized;
        }

        private void Update()
        {
            Vector3 direction = _target.position - transform.position;
            if (_activityDistance * _activityDistance < direction.sqrMagnitude)
                return;

            float dot = Vector3.Dot(direction.normalized, _initialForward);
            //Debug.Log(dot);
            /*
            if (dot <= _max)
                return;
            */
            //Vector3 rotation = Quaternion.LookRotation(direction).eulerAngles.ResetZ().ResetX();
            Vector3 rotation = Quaternion.LookRotation(direction).eulerAngles;
            transform.eulerAngles = rotation.Add(_offset).InversX();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}
