using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{

    [SerializeField] float initialForce;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject destination;
    Bow bow;

    // Start is called before the first frame update
    void Start()
    {
        bow = GameObject.FindObjectOfType<Bow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            launchArrow();
        }
    }

    private void launchArrow()
    {
        GameObject arrowGO = Instantiate(arrow,bow.transform.position,bow.transform.rotation);
        //arrowGO.GetComponent<Rigidbody2D>().AddForce((bow.transform.right * initialForce));//velocity = new Vector2(5f, 6f);//AddForce(bow.transform.right * 5f);//gravityScale = -10;//AddForce(bow.transform.forward * 5f);
       
        Vector2 appliedForce = bow.transform.right * initialForce;
        arrowGO.GetComponent<Rigidbody2D>().velocity = appliedForce;

        float t = appliedForce.y / 9.8f;// arrowGO.GetComponent<Rigidbody2D>().gravityScale;
        float s = appliedForce.x * (2*t) + bow.transform.position.x ;

        Instantiate(destination, new Vector3(s, 0, 0), bow.transform.rotation);
        float t1 = 0;
        while(t1<2*t)
        {
            float s1 = appliedForce.x * ( t1) + bow.transform.position.x;
            float s2 = appliedForce.y * t1 - (9.8f * t1 * t1) / 2 + bow.transform.position.y;
            Instantiate(destination, new Vector3(s1, s2, 0), bow.transform.rotation);
            t1 += 0.1f;
        }

        Debug.Log("time: " + t );
       
        

    }


}


