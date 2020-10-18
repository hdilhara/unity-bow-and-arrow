using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody2D rb;
    bool hitToBoard = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hitToBoard)
         adoptTodirection();
    }

    private void adoptTodirection()
    {
        Vector2 velocity = rb.velocity;
        transform.right = velocity;
    }

    public void onArrowHitToBoard()
    {
        hitToBoard = true;
        rb.simulated = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Square")
        onArrowHitToBoard();
    }
}
