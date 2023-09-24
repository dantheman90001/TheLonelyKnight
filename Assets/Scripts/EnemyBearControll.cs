using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBearControll : MonoBehaviour
{
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = Waypoint2.transform;
        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
