using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public int hp = 3;
    public List<Sprite> states;
    public int ammoToGive = 5;
    public int timeTillRespawn = 120;
    public SpriteRenderer shadowRenderer;
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
            shadowRenderer.enabled = false;
        }
        else
        {
            StartCoroutine(GoFromColorToColorIn(0.2f, Color.grey, Color.white));

        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(timeTillRespawn / 2, timeTillRespawn));
        spriteRenderer.enabled = true;
        c2d.enabled = true;
        shadowRenderer.enabled = true;
        hp = 3;
        spriteRenderer.sprite = states[hp - 1];
    }

    IEnumerator GoFromColorToColorIn(float seconds, Color colorFrom, Color colorTo)
    {
        spriteRenderer.color = colorFrom;
        yield return new WaitForSeconds(seconds);
        spriteRenderer.color = colorTo;
        spriteRenderer.sprite = states[Math.Clamp(hp - 1, 0, 2)];

    }

}
