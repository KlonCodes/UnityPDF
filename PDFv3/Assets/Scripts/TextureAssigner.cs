using UnityEngine;
using UnityEngine.UI;

public class TextureAssigner : MonoBehaviour
{
    public GameObject pagePlane;
    public GameObject[] pageWrap;
    public int pages = 90;

    void Start()
    {
        // Assuming 'n' textures and objects
        for (int i = 1; i <= pages; i++)
        {
            string textureName = "p_" + i;
            Texture newTexture = Resources.Load<Texture>("Thumbs/" + textureName);

            // Transform.Find  finds child by name
            Transform pc = pagePlane.transform.Find(textureName);
            if (pc != null)
            {
                RawImage ri = pc.GetComponent<RawImage>();
                if (ri != null)
                {
                    ri.texture = newTexture;
                }
                else
                {
                    Debug.LogError("RawImage not found on " + textureName);
                }
            }
            else
            {
                Debug.LogError("Child GameObject not found: " + textureName);
            }

            foreach (GameObject pwc in pageWrap)
            {
                Transform pw = pwc.transform.Find(textureName);
                if (pw != null)
                {
                    RawImage riw = pw.GetComponent<RawImage>();
                    if (riw != null)
                    {
                        riw.texture = newTexture;
                    }
                }
            }
        }
    }
}
