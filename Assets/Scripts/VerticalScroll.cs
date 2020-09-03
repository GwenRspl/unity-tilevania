using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour {

    [Tooltip("Game units per seconds")]
    [SerializeField] float scrollRate = 0.2f;

    private void Update() {
        float yMove = this.scrollRate * Time.deltaTime;
        this.transform.Translate(new Vector2(0f, yMove));
    }
}