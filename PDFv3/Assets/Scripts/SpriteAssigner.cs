using UnityEngine;

public class SpriteAssigner : MonoBehaviour
{
    public GameObject pagePlane; // Assign this in the inspector with your 'pagePlane' object
    public GameObject [] pageWrap; // Assign this in the inspector with your 'pagePlane' object
    public int pages = 90;

    void Start()
    {
        // Assuming you have 'n' number of sprites and game objects
        for (int i = 1; i <= pages; i++)
        {
            string spriteName = "p_" + i;
            //Sprite newSprite = Resources.Load<Sprite>("Thumbs/" + spriteName);

            Sprite newSprite = Resources.Load<Sprite>("Sprites/" + spriteName);

            // Use Transform.Find to find the child by name
            Transform pc = pagePlane.transform.Find(spriteName);
            if (pc != null)
            {
                SpriteRenderer sr = pc.GetComponent<SpriteRenderer>();
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

            foreach (GameObject pw in pageWrap)
            {
                // same for wrap
                Transform wt = pw.transform.Find(spriteName);
                if (wt != null)
                {
                    SpriteRenderer sr = wt.GetComponent<SpriteRenderer>();
                    if (sr != null)
                    {
                        sr.sprite = newSprite;
                    }
                    else
                    {
                        Debug.LogError("SpriteRenderer not found on " + spriteName);
                    }
                }

            }


        }
    }
}
