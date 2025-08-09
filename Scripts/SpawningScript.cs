using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public GameManager gm;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 6){
            Destroy(gameObject);
        }
        // Move left continuously
        rb.linearVelocity = Vector2.left * (speed + gm.speedMultiplier) ;
    }
}
