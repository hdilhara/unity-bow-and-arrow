using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    [SerializeField] Text mousePointDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display();

    }

    public void display()
    {
        Vector2 mousePoint= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        Vector2 direction = mousePoint - bowPos;
        mousePointDisplay.text = mousePoint.ToString() + "\n  " + bowPos + "\n" + direction;

        transform.right = direction ;
    }

}
