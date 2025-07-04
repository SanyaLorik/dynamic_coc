using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _KotletaGames.ArchitectureCore_M.UI
{
    /// <summary>
    /// TMPTextCollector is a Unity script that creates a child object to organize all child objects 
    /// with a TextMeshProUGUI component. The script skips objects that are listed in the exceptions list 
    /// or objects that already have a TMPTextCollector script attached. 
    /// This helps maintain a clean hierarchy and manage text components effectively in UI.
    /// </summary>
    public class TMPTextCollectorTool : MonoBehaviour
    {
        [Tooltip("List of objects to exclude from processing.")]
        public List<GameObject> exceptions = new List<GameObject>();

        /// <summary>
        /// Automatically runs on start to collect TextMeshProUGUI components in child objects.
        /// </summary>
        void Start()
        {
            CollectTMPChildren();
        }

        /// <summary>
        /// Creates a child object named 'CollectedTMPTexts' and moves all eligible TextMeshProUGUI 
        /// child objects into it, excluding objects listed in the exceptions or those with the same script.
        /// </summary>
        private void CollectTMPChildren()
        {
            // Create a new child object to serve as the container for collected texts
            GameObject textContainer = new GameObject("CollectedTMPTexts");
            RectTransform containerRect = textContainer.AddComponent<RectTransform>();
            containerRect.SetParent(transform);
            containerRect.localPosition = Vector3.zero;
            containerRect.localRotation = Quaternion.identity;
            containerRect.localScale = Vector3.one;

            // Get all TextMeshProUGUI components in child objects (including nested)
            TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>();

            foreach (var tmpComponent in textComponents)
            {
                GameObject child = tmpComponent.gameObject;

                // Skip objects that are in the exceptions list or have this script
                if (IsInExceptions(child) || child.GetComponent<TMPTextCollectorTool>() != null)
                {
                    Debug.Log($"Skipping {child.name}");
                    continue;
                }

                // Move the object to the container
                child.transform.SetParent(containerRect);
                Debug.Log($"Moved {child.name} to {textContainer.name}");
            }
        }

        /// <summary>
        /// Checks if a given object is in the exceptions list.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns>True if the object is in the exceptions list, otherwise false.</returns>
        private bool IsInExceptions(GameObject obj)
        {
            return exceptions.Contains(obj);
        }
    }
}
