using Unity.VisualScripting;
using UnityEngine;

public class ExtraAmmo : MonoBehaviour
{
    public int amount = 20;

    public float floatAmplitude = 0.5f;
    public float floatSpeed = 1f;

    public string weaponName = "";
    public int weapon;


    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            PlayerController player = collider2D.GetComponent<PlayerController>();
            player.SetWeapon(weapon);

            GameObject p = GameObject.Find(weaponName);
            p.GetComponent<PlayerWeapon>().AddAmmo(amount);
            Destroy(gameObject);
        }
    }
}
