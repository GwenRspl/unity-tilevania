using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {
    private int startingSceneIndex;

    private void Awake() {
        int numberOfScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if (numberOfScenePersist > 1) {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start() {
        this.startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != this.startingSceneIndex) {
            Destroy(this.gameObject);
        }
    }
}