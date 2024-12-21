using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text livesText;

    private Coroutine livesColorChange = null;


    public void SetHPBar(float hp)
    {
        healthSlider.SetValueWithoutNotify(hp);
    }

    public void AddToHPBar(float hp)
    {
        healthSlider.SetValueWithoutNotify(healthSlider.value + hp);
    }


    public void SetLivesSilently(int lives)
    {
        livesText.text = "" + lives;
    }

    public void IncreaseLives(int lives)
    {
        if (livesColorChange != null) StopCoroutine(livesColorChange);
        livesColorChange = StartCoroutine(GoFromColorToColorIn(0.2f, Color.green, Color.white, livesText));
        SetLivesSilently(lives);
    }

    public void DecreaseLives(int lives)
    {
        if (livesColorChange != null) StopCoroutine(livesColorChange);
        livesColorChange = StartCoroutine(GoFromColorToColorIn(0.2f, Color.red, Color.white, livesText));
        SetLivesSilently(lives);
    }


    IEnumerator GoFromColorToColorIn(float seconds, Color colorFrom, Color colorTo, TMP_Text text)
    {
        text.faceColor = colorFrom;
        yield return new WaitForSeconds(seconds);
        text.faceColor = colorTo;
    }
}
