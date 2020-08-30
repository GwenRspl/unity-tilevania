using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float climbSpeed = 5f;

    //State
    bool isAlive = true;

    //Cache
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Collider2D collider;
    private float gravityScaleAtStart;

    private void Start() {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.collider = GetComponent<Collider2D>();
        this.gravityScaleAtStart = this.rigidBody.gravityScale;
    }

    private void Update() {
        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
    }

    private void Run() {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * this.runSpeed, this.rigidBody.velocity.y);
        this.rigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(this.rigidBody.velocity.x) > Mathf.Epsilon;
        this.animator.SetBool("running", playerHasHorizontalSpeed);

    }

    private void ClimbLadder() {
        if (!this.collider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
            this.animator.SetBool("climbing", false);
            this.rigidBody.gravityScale = this.gravityScaleAtStart;
            return;
        }

        float controlThrow = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(this.rigidBody.velocity.x, controlThrow * this.climbSpeed);
        this.rigidBody.velocity = climbVelocity;
        this.rigidBody.gravityScale = 0;

        bool playerHasVerticalSpeed = Mathf.Abs(this.rigidBody.velocity.y) > Mathf.Epsilon;
        this.animator.SetBool("climbing", playerHasVerticalSpeed);
    }

    private void Jump() {
        if (!this.collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            return;
        }

        if (Input.GetButtonDown("Jump")) {
            Vector2 jumpVelocityToAdd = new Vector2(0f, this.jumpSpeed);
            this.rigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(this.rigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            this.transform.localScale = new Vector2(Mathf.Sign(this.rigidBody.velocity.x), 1f);
        }
    }

}