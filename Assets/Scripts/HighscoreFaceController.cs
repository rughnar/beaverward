using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreFaceController : MonoBehaviour
{
    [SerializeField] Sprite[] caras;
    Image image;


    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = caras[Random.Range(0,4)];
    }
}
