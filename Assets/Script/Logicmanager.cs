using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logicmanager : MonoBehaviour {
    public void startGame(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }

}
