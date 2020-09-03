using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 3;

    private void Awake() {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ProcessPlayerDeath() {
        if (this.playerLives > 1) {
            TakeLife();
        } else {
            ResetGameSession();
        }
    }

    private void TakeLife() {
        this.playerLives--;
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex);

    }

    private void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
    }

}