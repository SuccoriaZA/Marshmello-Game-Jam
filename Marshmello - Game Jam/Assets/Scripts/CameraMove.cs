using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject _player;

    private Vector2 playerpos;

    private Vector2 currentpos;

    public float distanceC;

    public float cameraFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = _player.gameObject.transform.position;
        currentpos = gameObject.transform.position;

        distanceC = Vector2.Distance(playerpos, currentpos);
    

        if (distanceC > cameraFollow)
        {
            gameObject.transform.position = playerpos;
        }
    }
}
