using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamController : MonoBehaviour
{

    public float _hp;
    private GameManager _gameManager;

    public void ReduceHealth(float hp)
    {
        _hp -= hp;
        if (hp <= 0) _gameManager.LoseGame();
    }

}
