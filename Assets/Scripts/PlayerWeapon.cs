using System.Collections;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{

    public Transform aimTransform;
    public SpriteRenderer spriteRenderer;

    public GameObject flashR;
    public GameObject flashL;
    public int framesToFlash = 5;

    public GameObject bullet;
    public float coolDown = .3f;
    public int fireRange = 100;

    private float nextTimeFire = 0f;
    private GameObject flash;

    void Start()
    {   
        flashL.SetActive(false);
        flashR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        aimTransform.rotation = rotation;

        spriteRenderer.flipY = direction.x < 0;
        flash = direction.x > 0 ? flashR : flashL;

        if (Input.GetButton("Fire1") && Time.time > nextTimeFire) {
            nextTimeFire = Time.time + coolDown;
        
            StartCoroutine(DoFlash());
            Instantiate(bullet, flash.transform.position, flash.transform.rotation);
        
            RaycastHit2D hit = Physics2D.Raycast(flash.transform.position, flash.transform.right);
            Debug.DrawLine(flash.transform.position, flash.transform.position + flash.transform.right * fireRange, Color.red, 0.5f);
            
            if (hit && hit.distance < fireRange && hit.collider.CompareTag("Enemy")) {
                Enemy e = hit.collider.GetComponent<Enemy>();
                e.TakeDMG();
            }
        }
    }

    IEnumerator DoFlash() {
        flash.SetActive(true);
        var framesFlashed = 0;

        while (framesFlashed < framesToFlash) {
            framesFlashed++;
            yield return null;
        }

        flash.SetActive(false);
        flashR.SetActive(false);
        flashL.SetActive(false);
    }
}
