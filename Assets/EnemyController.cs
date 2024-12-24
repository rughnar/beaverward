using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float attackPoints = 10;
    public float velocity = 1f;
    public float hp;
    public AudioClip destroy;
    private Rigidbody2D _rb;
    private AudioManager _audioManager;
    private EnemyManager _enemyManager;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioManager = FindObjectOfType<AudioManager>();
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    void FixedUpdate()
    {
        _rb.MovePosition(new Vector2(_rb.position.x, _rb.position.y - velocity * 0.01f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dam"))
        {
            other.gameObject.GetComponent<DamController>().ReduceHealth((int)attackPoints);
            Destroy(gameObject, 0.05f);
        }

    }

    public void ReduceHealth(float hp)
    {
        this.hp -= hp;
        if (this.hp <= 0)
        {
            //audioManager.PlaySFX(destroy);
            _enemyManager.EnemyTakenDown();

            Destroy(gameObject, 0.05f);
        }

    }

}
