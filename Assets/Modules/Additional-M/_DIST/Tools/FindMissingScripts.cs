using UnityEngine;

public class MissingScriptDetector : MonoBehaviour
{
    public void FindMissingScriptsInScene()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        int missingCount = 0;

        foreach (GameObject go in allObjects)
        {
            Component[] components = go.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"Missing script found on GameObject: {go.name}", go);
                    missingCount++;
                }
            }
        }

        Debug.Log($"Total missing scripts in scene: {missingCount}");
    }

    public void FindMissingScriptsInChildren()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>(true);
        int missingCount = 0;

        foreach (Transform child in allChildren)
        {
            Component[] components = child.GetComponents<Component>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] == null)
                {
                    Debug.LogWarning($"Missing script found on GameObject: {child.name}", child.gameObject);
                    missingCount++;
                }
            }
        }

        Debug.Log($"Total missing scripts in children: {missingCount}");
    }
}