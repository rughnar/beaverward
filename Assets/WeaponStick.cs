using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStick : MonoBehaviour
{
    public float damage;
    public AudioClip destroy;
    private AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().ReduceHealth(damage);
            //audioManager.PlaySFX(destroy);
            Destroy(gameObject, 0.05f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this);
    }

}
