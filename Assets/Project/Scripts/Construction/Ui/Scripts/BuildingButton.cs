using UnityEngine;
using UnityEngine.UI;

public class BuildingButton : MonoBehaviour
{
    [field: SerializeField] public Button Button { get; private set; }
    [field: SerializeField] public BuildingTemplate Template { get; private set; }
}