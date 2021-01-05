using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject lucidityState;
    private LucidityStats _lucidityStats;
    
    private Rigidbody2D _rb;

    public LayerMask groundLayer;
    public float groundRange = 0.2f;

    private bool _isGrounded;
    private bool _isJumping;

    public static PlayerMovement Instance;

    void Awake()
    {
        _lucidityStats = lucidityState.GetComponent<LucidityStats>();
        _rb = transform.GetComponent<Rigidbody2D>();
        if (Instance != null)
        {
            Debug.LogError("More than one player movement in scene!");
            return;
        }
        Instance = this;
    }

    public void SetLucidityState(GameObject newState)
    {
        lucidityState.SetActive(false);
        newState.SetActive(true);
        lucidityState = newState;
        _lucidityStats = lucidityState.GetComponent<LucidityStats>();
    }

    public GameObject GetLucidityState()
    {
        return lucidityState;
    }

    public void FixedUpdate()
    {
        // Check if we're grounded
        _isGrounded = Physics2D.OverlapCircle (transform.position, 0.2f, groundLayer); 
        
        // Horizontal movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            var movementX = Input.GetAxis("Horizontal") * _lucidityStats.horizontalSpeed * Time.deltaTime;
            transform.position += Vector3.right * movementX;
        }
        
        // Vertical Movement
        if (Input.GetAxis("Vertical") > 0 && !_isJumping && _isGrounded)
        {
            _rb.AddForce(Vector2.up * _lucidityStats.jumpPower, ForceMode2D.Impulse);
            _isJumping = true;
        }
        // Reset isJumping flag
        else if ((Input.GetAxis("Vertical") == 0 ||  _isGrounded) && _isJumping)
        {
            _isJumping = false;
        }
    }
}
