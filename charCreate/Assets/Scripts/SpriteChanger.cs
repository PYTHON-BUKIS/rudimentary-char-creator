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

//this errors sometimes in the editor, IDK what's wrong with it. something about the UI is breaking it...but IDK 
//If you understand please tell me, this has been bothering me for the past hour working on this
//if it works it works i guess 50% of the time...I know there's an easier way of doing this
//but sadly that error and my lack of understanding made me take the longer route...
//phantom error 
//HI SIR :]