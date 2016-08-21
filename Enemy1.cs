using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {


    //vars
    public int currHealth;
    public int maxHealth;

    public float distance;
    public float walkRange;

    public bool playerNear = false;
    //public bool walking = true;

    public Animator anim;
    public Transform target;


    private Rigidbody2D rb2d;
    private int speed = 5;
  //  private float currentpos;

    Transform enemy;

    // use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        currHealth = maxHealth;
     //   currentpos = transform.position.x;

    
    }

    // update is called once per frame
    void Update()
    {

        //    rangecheck();
        anim.SetBool("playerNear", playerNear);

         RangeCheck();

   //     transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);


     //   transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90,0));//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) < walkRange)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        //move left
        //        if (target.transform.position.x < currentpos)//transform.position.x)
        //      {
   //     if (playerNear)
     //   {
            //            transform.localscale = new vector3(1, 1, 1);
        //   rb2d.velocity = new vector2(speed, rb2d.velocity.y);
          //  transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        //}
       // else
     //   {
         //   rb2d.velocity = new vector2(0, rb2d.velocity.y);
        //}
        //     }
        //    rb2d.velocity = new vector2(speed, rb2d.velocity.y);
        //  transform.localscale = new vector3(-1, 1, 1);
        // //move enemy left
        // if (target.transform.position.x < transform.position.x)
        // {
        //     debug.log("da beat go awf");
        //     if (distance <= walkrange)//(transform.position.x > 2)// < walkrange)
        //     {
        //         debug.log("ayeee");
        //         nextpoint();
        //      //  if (input.getaxis("horizontal") < -0.1f)
        //        //     debug.log("ayee2");
        //          //   transform.localscale = new vector3(-1, 1, 1);
        //         }

        // }
        ////move enemy right
        //if (target.transform.position.x > transform.position.x)
        //     {
        //     debug.log("da beat go hawd");
        //     if (transform.position.x < walkrange)
        //         { 
        //             if (input.getaxis("horizontal") > 0.1f)
        //                 transform.localscale = new vector3(1, 1, 1);

        //         }
        //     }

    }

    // //  void NextPoint()
    //   //{
    //     //  agent.destination = points[dest].position;

    //       //dest = (dest + 1) % points.Length;
    //    //}

    void RangeCheck()
    {

        //calculates the distance between enemy and player
        distance = Vector3.Distance(transform.position, target.transform.position);

        //if player is out of the enemy range, stop walking
        if (distance > walkRange)
            playerNear = false;

        if (distance < walkRange)
            playerNear = true;
    }
}
