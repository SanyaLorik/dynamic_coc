using UnityEngine;

public class GameConfig : MonoBehaviour
{
    [field: SerializeField] public float PlayerMovementSpeed { get; private set; }
    [field: SerializeField] public float PlayerRotationSpeed { get; private set; }
}