using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamController : MonoBehaviour
{

    public int _hp = 100;
    private GameManager _gameManager;
    private UIController UIController;


    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        UIController = FindObjectOfType<UIController>();
        UIController.SetLivesSilently(_hp);
    }

    public void ReduceHealth(int hp)
    {
        _hp -= hp;
        UIController.DecreaseLives(_hp);

        if (_hp <= 0) _gameManager.LoseGame();
    }

    public void AddHealth(int hp)
    {
        if (_hp + hp < 100)
        {
            _hp += hp;
            UIController.IncreaseLives(_hp);
        }
        else
        {
            _hp = 100;
        }

    }

}
