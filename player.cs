using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    //variables
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 400f;

    public bool grounded;
    //boolean for double jumping
    public bool canDjump;

    private Rigidbody2D rb2d;
    private Animator anim;

    //health
    public int currHealth;
    public int maxHealth = 5;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("Grounded", grounded);
        //getting actual speed of player
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //flip sprite
        //moving left
        if(Input.GetAxis("Horizontal") < -0.1f) {

            transform.localScale = new Vector3(-1, 1, 1);
        }

        //moving right
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            
            transform.localScale = new Vector3(1, 1, 1);
        }

        //jumping
        if(Input.GetButtonDown("Jump"))  {
            //if the player is on the ground
            if (grounded) {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDjump = true;
            }
            else {
                //if the player is already in the air, and they haven't already double jumped
                if (canDjump)
                {
                    canDjump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    //create the 2nd jump, jumps with a little less force
                    rb2d.AddForce(Vector2.up * (jumpPower/1.25f));
                }
            }
        }

        if (currHealth > maxHealth)
            currHealth = maxHealth;

        if (currHealth <= 0)
            Death();

    }

    void FixedUpdate(){

        Vector3 isVelocity = rb2d.velocity;
        isVelocity.y = rb2d.velocity.y;
        isVelocity.x = isVelocity.x * 0.75f;
        isVelocity.z = 0.0f;

        //make friction on ground using xspeed of player
        if (grounded){

            rb2d.velocity = isVelocity;
        }

        //moving player horizontally
        float hor = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed) * hor);

        //limiting speed of player
        if (rb2d.velocity.x > maxSpeed) {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if(rb2d.velocity.x < -maxSpeed) {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    void Death() {
        //restart game
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Damage(int dmg)    {
        
          currHealth = currHealth - dmg;

        //flash player red
        gameObject.GetComponent<Animation>().Play("playerRed");
    }

    public IEnumerator KnockBack(float knockDur, float knockPow, Vector3 knockDir) {

        float timer = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

        //while the duration of the knockback is greater than the time
        while (knockDur > timer)
        {
            timer = timer + Time.deltaTime;

            //knock player back in opposite direction
            rb2d.AddForce(new Vector3(knockDir.x * -100, knockDir.y * knockPow, transform.position.z));
           
        }

        yield return 0;
    }
}
