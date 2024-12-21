using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INS;
    public float tiempo = 60;
    [HideInInspector] public int cantidadObstaculosChocados = 0;

    private UIController uiController;
    private bool tiempoParado = false;
    private float coolDownTiempoParado = 5;

    public float tiempoDeJuegoReal = 0;

    private void Awake()
    {
        INS = this;
        uiController = FindObjectOfType<UIController>();
        //uiController.SetTimer((int)System.Math.Round(tiempo, 2));

    }

    void Update()
    {
        if (tiempo >= 0 && !tiempoParado)
        {
            tiempo -= Time.deltaTime;
            //uiController.SetTimer((int)System.Math.Round(tiempo, 0));
        }
        else if (tiempoParado)
        {
            //EmpezarCooldownTiempoParado();

        }
        else
        {
            SceneManager.LoadScene("Score");
        }

        tiempoDeJuegoReal += Time.deltaTime;
        //Debug.Log(tiempoDeJuegoReal);
    }

    private void OnDisable()
    {
        Score();
    }



    private void Score()
    {
        //Formula: (6000 * cantidad de segundos ) - 70 * cantidad de obst�culos chocados
        string score = ((600 * (int)tiempoDeJuegoReal) - 70 * cantidadObstaculosChocados).ToString();
        PlayerPrefs.SetString("score", score);
        PlayerPrefs.Save();
    }


}
