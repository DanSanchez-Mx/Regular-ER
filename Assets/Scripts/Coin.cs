using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // Parte del codigo para destruir el objeto
        if (timer > 3.5)
        {
            Destroy(gameObject);
        }

        rb.velocity = Vector2.left * (speed);
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 1, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            PlayerManager.numCoins++;
            PlayerPrefs.SetInt("numCoins", PlayerManager.numCoins);
            Destroy(gameObject);
        }
    }
}
