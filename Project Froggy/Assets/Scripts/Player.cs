using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;

    private Rigidbody rb;
    private Vector3 movementInput;

    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Klavye giriþini al
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Hareket giriþi vektörünü oluþtur
        movementInput = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Klavye giriþi kesildiðinde hýzý sýfýrla
        if (movementInput == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }

        animator.SetBool("isHorizontalWalking", movementInput != Vector3.zero);

        if(movementInput.x != 0) 
        {
            transform.localScale = new Vector3(x: Mathf.Sign(movementInput.x), y: 1, z: 1);
        }
    }

    void FixedUpdate()
    {
        // Hareket giriþi varsa, karakteri hareket ettir
        if (movementInput != Vector3.zero)
        {
            rb.velocity = movementInput * speed * Time.fixedDeltaTime;
        }
    }
}
