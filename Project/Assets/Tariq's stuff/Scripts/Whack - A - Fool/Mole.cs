using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Mole;

public class Mole : MonoBehaviour
{
    [Header("Graphics")]
    [SerializeField] private Sprite mole;
    [SerializeField] private Sprite molehardHat;
    [SerializeField] private Sprite molehatBroken;
    [SerializeField] private Sprite molehit;
    [SerializeField] private Sprite molehathit;

    //--------------------------------------------------------------//

    private Vector2 startPosition = new Vector2(0f, -2.60f);
    private Vector2 endPosition = Vector2.zero;
    private float showDuration = 0.5f;
    private float duration = 1f;

    //--------------------------------------------------------------//

    private SpriteRenderer spriteRenderer;

    //--------------------------------------------------------------//

    private bool hitable = true;

    //--------------------------------------------------------------//

    public enum MoleType { Standard, hardHat, Bomb };
    private MoleType moleType;
    private float hardrate = 0.25f;
    private int lives;
    //--------------------------------------------------------------//--------------------------------------------------------------//--------------------------------------------------------------
    
    private IEnumerator ShowHide(Vector2 start, Vector2 end)
    {
        transform.localPosition = start;

        float elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        //--------------------------------------------------------------

        transform.localPosition = end;
        yield return new WaitForSeconds(duration);

        elapsed = 0f;
        while (elapsed < showDuration)
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        //--------------------------------------------------------------

        transform.localPosition = start;
    }

    void Start()
    {
        CreateNext();
        StartCoroutine(ShowHide(startPosition, endPosition));
    } 

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if(hitable)
        {
            switch (moleType)
            {
                case MoleType.Standard:
                    spriteRenderer.sprite = molehit;
                    StopAllCoroutines();
                    StopCoroutine(QuickHide());
                    hitable = false;
                    break;

                case MoleType.hardHat:
                    if (lives == 2)
                    {
                        spriteRenderer.sprite = molehatBroken;
                        lives--;
                    }
                    else
                    {
                        spriteRenderer.sprite= molehathit;
                        StopAllCoroutines();
                        StopCoroutine(QuickHide());
                        hitable = false;
                    }
                    break;
                case MoleType.Bomb:
                    break;
                default:
                    break;
            }    
        }
    }

    private IEnumerator QuickHide()
    {
        yield return new WaitForSeconds(0.25f);

        if (!hitable)
        {
            Hide();
        }
    }

    private void Hide()
    {
        transform.localPosition = startPosition;
    }

    private void CreateNext()
    {
        float random = Random.Range(0f, 1f);
        if (random < hardrate)
        {
            moleType = MoleType.hardHat;
            spriteRenderer.sprite = molehardHat;
            lives = 2;
        }

        else
        {
            moleType = MoleType.Standard;
            spriteRenderer.sprite = mole;
            lives = 1;
        }

        hitable = false;
    }
}
