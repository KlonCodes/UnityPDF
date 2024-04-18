using UnityEngine;

public class GridScript : MonoBehaviour
{
    public Sprite[] sprites; // Public array of sprites
    public int columns = 5; // Number of columns in the grid
    public float scale = 0.001f; // Scale factor (10% of the original size)

    void Start()
    {
        Vector2 startPosition = transform.position; // Top-left corner of the grid

        for (int i = 0; i < sprites.Length; i++)
        {
            // Create a new GameObject for each sprite
            GameObject spriteObj = new GameObject(sprites[i].name);
            spriteObj.transform.parent = transform;

            // Add a SpriteRenderer component and assign the sprite
            SpriteRenderer renderer = spriteObj.AddComponent<SpriteRenderer>();
            renderer.sprite = sprites[i];

            // Scale the sprite
            spriteObj.transform.localScale = new Vector3(scale, scale, 1);

            // Calculate the position based on the index
            float xPosition = startPosition.x + (i % columns) * (renderer.bounds.size.x * scale);
            float yPosition = startPosition.y - (i / columns) * (renderer.bounds.size.y * scale);

            // Set the position
            spriteObj.transform.position = new Vector2(xPosition, yPosition);
        }
    }
}
