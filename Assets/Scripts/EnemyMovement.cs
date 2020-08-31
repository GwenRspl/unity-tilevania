using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidBody;

    private void Start() {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (IsFacingRight()) {
            this.rigidBody.velocity = new Vector2(this.moveSpeed, 0f);
        } else {
            this.rigidBody.velocity = new Vector2(-this.moveSpeed, 0f);
        }
    }

    private bool IsFacingRight() {
        return this.transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D other) {
        this.transform.localScale = new Vector2(-(Mathf.Sign(this.rigidBody.velocity.x)), 1f);
    }
}