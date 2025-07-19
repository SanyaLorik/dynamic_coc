using Cysharp.Threading.Tasks;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    [SerializeField] private AnimationCurve _trajectory;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private float _height = 5f;

    public async UniTask MoveAsync(Transform missile, Vector3 target)
    {
        Vector3 startPosition = missile.position;

        float elapsed = 0f;

        while (elapsed < _duration && destroyCancellationToken.IsCancellationRequested == false)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / _duration;

            // ������� �� ������
            Vector3 linearPosition = Vector3.Lerp(startPosition, target, progress);

            // ������������ �������� �� ������
            float verticalOffset = _trajectory.Evaluate(progress) * _height;

            // �������� �������
            missile.position = linearPosition + Vector3.up * verticalOffset;

            // ������� � ����������� ��������
            if (progress < 0.95f) // ����� �� �������� � �����
            {
               missile.forward = (linearPosition + Vector3.up * verticalOffset - missile.position).normalized/* + new Vector3(0.01f, 0.01f, 0.01f)*/;
            }

            await UniTask.Yield(destroyCancellationToken);
        }

        missile.position = target;
    }
}
