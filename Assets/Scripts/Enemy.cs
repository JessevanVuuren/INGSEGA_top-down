using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public GameObject target;
    NavMeshAgent agent;
    public int hp;
    public int maxHealth = 100;
    public int rotateSprite = 90;

    public HealthBar healthBar;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        target = GameObject.Find("Player");
        hp = maxHealth;
        healthBar.SetHealth(hp, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.transform.position);

            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - rotateSprite);

        }
        else
        {
            target = GameObject.Find("Player");
        }

    }

    public void TakeDMG()
    {
        hp -= 10;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        healthBar.SetHealth(hp, maxHealth);


    }
}
