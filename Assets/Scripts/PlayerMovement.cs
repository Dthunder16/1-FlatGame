using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InteractionDetector interactionDetector;

    [SerializeField] private float moveSpeed = 1.8f;

    //Transform Component
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _animator;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.IsGamePaused)
        {
            rb.linearVelocity = Vector3.zero; //stop movement
            _animator.SetBool("isRunning", false);
            return;
        }
        PlayerInput();
    }

    void PlayerInput()
    {
        //GetKeyDown -> only first time it is pressed it will update -> use for jumping
        //GetKey -> 
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            _playerTransform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            _playerTransform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            _playerTransform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            _playerTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        //Player Interaction
        if (Input.GetKey(KeyCode.E))
        {
            interactionDetector.TryInteract();
        }


        //Flipping Sprite
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX > 0){
            sr.flipX = false;
            _animator.SetBool("isRunning", true);
        }
        else if (moveX < 0){
            sr.flipX = true;
            _animator.SetBool("isRunning", true);
        }
        else
            _animator.SetBool("isRunning", false);
    }
}
