using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class for walking enemy
[RequireComponent(typeof(Controller2D))]
public class Foe : MonoBehaviour {

    Controller2D controller;
	SpriteRenderer sprite;
    Animator animator;
    Vector3 velocity;

    public float jumpHeight = 4;
    public float timeToJumpApex = 0.4f;
    public float moveSpeed = 6;
    public float direction = -1;

	// change direction when reaching the end of a platform
    public bool flipAtPlatformEnd = false;
	// flip sprite when walking left
    public bool flipSprite = false;
    float gravity;

	protected FiniteStateMachine state;

	public float vx {
		get { return velocity.x; }
		set { velocity.x = value; }
	}
	public float vy {
		get { return velocity.y; }
		set { velocity.y = value; }
	}

	public Controller2D Controller { get { return controller; } }
	public Animator anim { get { return animator; } }

	public void Init() {
		controller = GetComponent<Controller2D>();
		sprite = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
		gravity = -(2 * jumpHeight) / (Mathf.Pow(timeToJumpApex, 2));
		if (flipSprite)
			sprite.flipX = direction < 0;	
	}


    // Use this for initialization
    void Start()
    {
		Init ();
    }

//    public void JumpOn()
//    {
//        animator.SetBool("dead", true);
//        dead = true;
//        var collider = GetComponent<BoxCollider2D>();
//        collider.size = new Vector2(1.0f, 0.5f);
//        transform.Translate(new Vector3(0.0f, -0.25f, 0.0f));
//        //collider.enabled = false;
//        //GetComponent<Rigidbody2D>().
//    }

    // Update is called once per frame
    void Update()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        
		state.Update ();

		if (flipSprite)
		{
			sprite.flipX = direction < 0;
		}
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
