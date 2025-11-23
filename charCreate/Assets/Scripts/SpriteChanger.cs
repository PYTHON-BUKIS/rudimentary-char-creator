using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetRenderer;
    [SerializeField] private Sprite[] sprites;

    [SerializeField, HideInInspector] private int index = 0;
    public int CurrentIndex => index;

    private void Awake()
    {
        UpdateSprite();
    }

    private void OnValidate()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (targetRenderer != null && sprites != null && sprites.Length > 0)
        {
            index = Mathf.Clamp(index, 0, sprites.Length - 1);
            targetRenderer.sprite = sprites[index];
        }
    }

    public void NextSprite()
    {
        if (sprites == null || sprites.Length == 0) return;

        index = (index + 1) % sprites.Length;
        UpdateSprite();
    }

    public void PreviousSprite()
    {
        if (sprites == null || sprites.Length == 0) return;

        index = (index - 1 + sprites.Length) % sprites.Length;
        UpdateSprite();
    }
}
