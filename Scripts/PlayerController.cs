using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverUI;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("PlayerController initialized");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Debug.Log("JumpRegistered");
            rb.AddForce(Vector2.up*jumpForce);
        }
        
        // Crouch: hold to crouch, release to stop crouching
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool("isCrouching", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("isCrouching", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
            Debug.Log("Grounded!");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyHit");

            // Show Game Over UI instead of restarting
            gameOverUI.SetActive(true);

            // Optional: stop player movement
            Time.timeScale = 0f;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = false;
            Debug.Log("Not grounded!");
        }
    }
}
