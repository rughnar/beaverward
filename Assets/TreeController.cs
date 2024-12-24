using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public int hp = 3;
    public List<Sprite> states;
    public int ammoToGive = 5;
    public int timeTillRespawn = 120;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Collider2D c2d;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        c2d = GetComponent<Collider2D>();
    }

    public void ReduceHealth()
    {
        hp -= 1;
        if (hp <= 0)
        {
            StartCoroutine(Respawn());
            spriteRenderer.enabled = false;
            c2d.enabled = false;
        }
        else
        {
            StartCoroutine(GoFromColorToColorIn(0.5f, Color.red, Color.white));

        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(Random.Range(timeTillRespawn / 2, timeTillRespawn));
        spriteRenderer.enabled = true;
        c2d.enabled = true;
    }

    IEnumerator GoFromColorToColorIn(float seconds, Color colorFrom, Color colorTo)
    {
        spriteRenderer.color = colorFrom;
        yield return new WaitForSeconds(seconds);
        spriteRenderer.color = colorTo;
        spriteRenderer.sprite = states[hp];

    }

}
