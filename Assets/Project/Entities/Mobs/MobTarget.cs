using UnityEngine;

public class MobTarget
{
    public Vector3 Target { get; private set; }

    public MobTarget(Vector3 target)
    {
        Target = target;
    }
}
