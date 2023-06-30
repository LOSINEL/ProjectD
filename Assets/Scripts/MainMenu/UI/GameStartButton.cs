using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickGameStartButton);
    }

    void OnClickGameStartButton()
    {
        SceneManager.LoadScene(Strings.sceneNames[(int)Enums.SCENE_TYPE.IN_GAME]);
    }
}