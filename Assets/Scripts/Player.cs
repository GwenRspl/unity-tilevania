using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Config
    [SerializeField] float runSpeed = 5f;

    //State
    bool isAlive = true;

    //Cache
    private Rigidbody2D rigidBody;
    private Animator animator;

    private void Start() {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    private void Update() {
        Run();
        FlipSprite();
    }

    private void Run() {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * this.runSpeed, this.rigidBody.velocity.y);
        this.rigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(this.rigidBody.velocity.x) > Mathf.Epsilon;
        this.animator.SetBool("running", playerHasHorizontalSpeed);

    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(this.rigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            this.transform.localScale = new Vector2(Mathf.Sign(this.rigidBody.velocity.x), 1f);
        }
    }

}