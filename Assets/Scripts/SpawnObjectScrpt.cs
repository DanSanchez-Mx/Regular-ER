using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScrpt : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public Transform exitPoint;

    private EnemyManager EM;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EM = GameObject.FindGameObjectWithTag("Enemy Manager").GetComponent<EnemyManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * (speed + EM.speedMultipplier);
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            EnemyManager.sharedInstance.DestroyEnemy();
        }
    }
}
