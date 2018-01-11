using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

    Controller2D controller;
    SpriteRenderer sprite;
    Animator animator;
    Vector3 velocity;
    public float jumpHeight = 4;
    public float timeToJumpApex = 0.4f;
    public float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .1f;
    float jumpVelocity;
    float moveSpeed = 6;
    float gravity;
    float velocityXSmoothing;
    bool dead = false;
    float deadTimer = 0.0f;

	// Use this for initialization
	void Start () {
        controller = GetComponent<Controller2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gravity = -(2 * jumpHeight) / (Mathf.Pow(timeToJumpApex, 2));
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
	}
	
	// Update is called once per frame
	void Update () {
        if (dead)
        {
            // handle dead case
            deadTimer += Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            transform.Translate(velocity * Time.deltaTime);
            if (deadTimer > 2)
            {
                Scene loadedLevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene(loadedLevel.buildIndex);
            }
            return;
        }


        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));
        if (input.x != 0)
        {
            sprite.flipX = input.x < 0;
        }
        

        if (Input.GetKeyDown(KeyCode.LeftControl) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }
        float targetVelocity = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocity, ref velocityXSmoothing, (controller.collisions.below ? accelerationTimeGrounded : accelerationTimeAirborne));
        velocity.y += gravity * Time.deltaTime;

        animator.SetInteger("dir", input.x < 0 ? -1 : (input.x > 0 ? 1 : 0));
        animator.SetFloat("speed", velocity.x);
        animator.SetBool("grounded", controller.collisions.below);
        controller.Move(velocity * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Goomba"))
        {
//            var foe = collision.gameObject.GetComponent<Foe>();
//            if (foe.Dead)
//                return;
//            var collider = GetComponent<Collider2D>();
//            var dir = collision.Distance(collider);
//            if (dir.normal == Vector2.up)
//            {
//                velocity.y *= -1.0f;
//                foe.JumpOn();
//            }
//            else
//            {
//                animator.SetBool("dead", true);
//                velocity = new Vector3(0, 10, 0);
//                dead = true;
//                //collision.gameObject.
//                Debug.Log("Colliding with Goomba!");
//            }
        }

    }
}
