using UnityEngine;

public class EnemyDislocation : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _radius;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_center.position, _radius);
    }

    public Vector3 GetPosition()
    {
        float random = UnityEngine.Random.Range(-1, 1);
        return _center.position + new Vector3()
        {
            x = _radius * Mathf.Cos(random),
            z = _radius * Mathf.Sin(random),
        };
    }
}
