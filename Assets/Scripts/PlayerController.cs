using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 4f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject camera_pos;
    public float smoothSpeed = 0.125f;
    public int hp = 100;

    private Vector2 movement; // Stores the direction of player movement

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0) animator.Play("WalkRight");
        else if (horizontal < 0) animator.Play("WalkLeft");
        else if (vertical > 0) animator.Play("WalkBackward");
        else if (vertical < 0) animator.Play("WalkForward");
        else animator.Play("IDLE");

        movement = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;

        Vector3 smoothPos = Vector3.Lerp(camera_pos.transform.position, transform.position, smoothSpeed);
        smoothPos.z = -10;
        camera_pos.transform.position = smoothPos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Enemy")) {
            hp -= 10;
        }

        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
}
