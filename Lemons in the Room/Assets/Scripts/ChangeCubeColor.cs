using UnityEngine;

public class ChangeCubeColor : MonoBehaviour
{
    // Assign the cube (or any mesh) in the Inspector
    [SerializeField] private Renderer targetRenderer;

    // This method can be called by the button event
    public void ChangeColor()
    {
        if (targetRenderer == null)
        {
            Debug.LogWarning("Target Renderer not set in the inspector!");
            return;
        }

        // Create a random color
        Color randomColor = new Color(
            Random.Range(0f, 1f),  // R
            Random.Range(0f, 1f),  // G
            Random.Range(0f, 1f)   // B
        );

        // Apply it to the material
        targetRenderer.material.color = randomColor;
    }
}
