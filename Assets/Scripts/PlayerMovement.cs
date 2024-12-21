using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 1f;
    public AudioClip moverseClip;
    private InputAction _moverse;
    private AudioManager _audioManager;
    private Rigidbody2D _rb;
    private PlayerInputActions _playerActions;


    private Vector2 _moveInput;

    private void Awake()
    {
        _playerActions = new PlayerInputActions();
        _audioManager = FindObjectOfType<AudioManager>();
        _rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        _moverse = _playerActions.Player.Move;
        _moverse.Enable();
        //_moverse.performed += Moverse;


    }

    private void OnDisable()
    {
        _moverse.Disable();
    }

    void FixedUpdate()
    {
        _moveInput = _playerActions.Player.Move.ReadValue<Vector2>();
        _rb.MovePosition(new Vector2(_rb.position.x + _moveInput.x * 0.01f * velocidad, _rb.position.y + _moveInput.y * 0.01f * velocidad));
    }
    /*
        private void Moverse(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.)
            {
                _moveInput = _playerActions.Player.Move.ReadValue<Vector2>();
                _rb.MovePosition(new Vector2(_rb.position.x + _moveInput.x * 0.01f * velocidad, _rb.position.y + _moveInput.y * 0.01f * velocidad));
                //audioManager.PlaySFX(moverseClip);
            }
        }
    */
}
