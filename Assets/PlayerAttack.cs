using UnityEngine.InputSystem;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackClip;
    public GameObject weaponStickPrefab;
    public float throwVelocity = 16f;
    public int ammo = 10;
    private PlayerInputActions _playerActions;
    private InputAction _attack;
    private AudioManager _audioManager;
    private Camera _cam;
    private UIController _uiController;

    private void Awake()
    {
        _playerActions = new PlayerInputActions();
        _audioManager = FindObjectOfType<AudioManager>();
        _cam = FindObjectOfType<Camera>();
        _uiController = FindObjectOfType<UIController>();
        _uiController.SetLivesSilently(ammo);
    }


    private void OnEnable()
    {
        _attack = _playerActions.Player.Fire;
        _attack.Enable();
        _attack.performed += Attack;
    }

    private void OnDisable()
    {
        _attack.Disable();
    }

    private void Attack(InputAction.CallbackContext callbackContext)
    {
        if (ammo > 0)
        {
            GameObject ws = Instantiate(weaponStickPrefab, this.transform.position, Quaternion.identity);
            Rigidbody2D rb = ws.GetComponent<Rigidbody2D>();//
            Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            rb.velocity = lookDir.normalized * throwVelocity;
            Debug.Log("dispare");
            ammo -= 1;
            _uiController.DecreaseLives(ammo);
            //audioManager.PlaySFX(attackClip);
        }
        else
        {
            Debug.Log("Me quede sin ramitas");
        }

    }



    private void OnBecameInvisible()
    {
        Destroy(this);
    }
}
