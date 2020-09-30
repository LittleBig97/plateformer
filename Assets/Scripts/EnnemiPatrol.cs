using UnityEngine;

public class EnnemiPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;

    private Transform target;
    private int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
        Debug.Log("oui");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        graphics.flipX = !graphics.flipX;

        //Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("non");
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("oui2");
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);
            
        }
    }
}
