using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AmbientSounds : MonoBehaviour
{

    public Collider Area;
    public GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //locate closest point on the collider to the player
        Vector3 ClosestPoint = Area.ClosestPoint(Player.transform.position);
        //set position to the closest point to the player
        transform.position = ClosestPoint;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
