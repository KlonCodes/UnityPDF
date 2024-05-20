using UnityEngine;

public class SpriteAssigner : MonoBehaviour
{
    public GameObject pagePlane; // Assign this in the inspector with your 'pagePlane' object

    void Start()
    {
        // Assuming you have 'n' number of sprites and game objects
        for (int i = 1; i <= 30; i++)
        {
            string spriteName = "p_" + i;
            Sprite newSprite = Resources.Load<Sprite>("Sprites/" + spriteName);

            // Use Transform.Find to find the child by name
            Transform childTransform = pagePlane.transform.Find(spriteName);
            if (childTransform != null)
            {
                SpriteRenderer sr = childTransform.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sprite = newSprite;
                }
                else
                {
                    Debug.LogError("SpriteRenderer not found on " + spriteName);
                }
            }
            else
            {
                Debug.LogError("Child GameObject not found: " + spriteName);
            }
        }
    }
}
