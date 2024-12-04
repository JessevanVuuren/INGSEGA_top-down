using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 4f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject camera_pos;
    public float smoothSpeed = 0.125f;
    public int maxHP = 100;
    private int hp;
    public float timeBetweenDmg = 1;
    private float currentTime = 0;
    public HealthBar healthBar;

    public GameObject gunPistol;
    public GameObject gunRifle;
    public GameObject gunMinigun;
    public int activeWeapon = 0;

    private Vector2 movement; // Stores the direction of player movement

    public void SetWeapon(int active) {
        gunPistol.SetActive(active == 0);
        gunRifle.SetActive(active == 1);
        gunMinigun.SetActive(active == 2);
    }

    void Start()
    {
        SetWeapon(activeWeapon);

        hp = maxHP;
        healthBar.SetHealth(hp, maxHP);
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

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            activeWeapon++;
            activeWeapon %= 3;
            SetWeapon(activeWeapon);
        } 

        movement = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;

        Vector3 smoothPos = Vector3.Lerp(camera_pos.transform.position, transform.position, smoothSpeed);
        smoothPos.z = -10;
        camera_pos.transform.position = smoothPos;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && Time.time > currentTime)
        {
            currentTime = Time.time + timeBetweenDmg;
            hp -= 10;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.SetHealth(hp, maxHP);
    }
}
