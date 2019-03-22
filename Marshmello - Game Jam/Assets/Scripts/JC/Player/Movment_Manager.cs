using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment_Manager : MonoBehaviour
{

    public Vector2 posP1;
    public Vector2 posP2;

    private Vector2 screenpoint;
    private Vector2 screenpoint2;

    public Vector2 offset;
     public Rigidbody2D rb;

     public float _speedShoot;

     public float distanC; 

     public bool dragA;

     private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody2D>();
      rb.isKinematic = true; 

      lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    
      //button  
    }

    
    void OnMouseDrag()
    {
      //if (other.transform.tag == "Player")
     // {
       if(dragA == true)
       {
           Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
           Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
           transform.position = curPosition;

           lineRenderer.SetPosition(1, curPosition);

           distanC = Vector2.Distance(curScreenPoint, screenpoint);
           if (distanC > 50)
           {

             dragA = false;
           // curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            // transform.position = curPosition;
            // if(distanC < 50)
            // {
            //   OnMouseDrag();
            // }

            }
       }else 
       if(dragA == false)
       {
           Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
           Vector2 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
          // transform.position = curPosition;

           distanC = Vector2.Distance(curScreenPoint, screenpoint);

           if(distanC < 49)
           {
             dragA = true;
           }
       }
     // }
    }

    void OnMouseDown()
    {
     // if (other.transform.tag == "Player")
    //  {
        screenpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        posP1 = transform.position;
        lineRenderer.SetPosition(0,posP1);
      

     // }
    }

    void OnMouseUp()
    {
      //posP2 = transform.position;

      screenpoint2 = Camera.main.WorldToScreenPoint(gameObject.transform.position);

      Vector2 shoot = screenpoint-screenpoint2;
      rb.isKinematic = false;
      rb.AddForce(shoot*_speedShoot, ForceMode2D.Impulse);


    }
}
