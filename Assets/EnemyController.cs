using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float velocity = 1f;
    public float hp;
    public AudioClip destroy;
    private Rigidbody2D rb;
    private AudioManager _audioManager;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(new Vector2(rb.position.x, rb.position.y - velocity * 0.01f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dam")) Debug.Log("Le pegue a la represa");//ReduceHealth();
    }

    public void ReduceHealth(float hp)
    {
        this.hp -= hp;
        if (hp <= 0)
        {
            //audioManager.PlaySFX(destroy);
            Destroy(gameObject, 0.05f);
        }

    }
}
