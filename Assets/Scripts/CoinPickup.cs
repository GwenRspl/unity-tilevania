using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int points = 10;

    private void OnTriggerEnter2D(Collider2D other) {
        FindObjectOfType<GameSession>().AddToScore(this.points);
        AudioSource.PlayClipAtPoint(this.coinPickupSFX, Camera.main.transform.position);
        Destroy(this.gameObject);
    }
}