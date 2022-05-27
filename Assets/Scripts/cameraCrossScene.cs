using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraCrossScene : MonoBehaviour
{
    int sceneIndex;
    string text;
    public static cameraCrossScene instance;

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    void CameraOperation(){
        if (Input.GetMouseButton(0))
        {
            text = "我可以滑动";
        }
        else if (Input.GetMouseButtonDown(0))
        {
            text = " ";
        }
    }
    
    private void Update() {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetMouseButtonDown(1))
        {
            if(++sceneIndex > 2)
            {
                sceneIndex = 0;
            }
            SceneManager.LoadScene(sceneIndex);
        }
        CameraOperation();
    }

    private void OnGUI() {
        GUI.Label(new Rect(20, 20, 500, 500), "这是场景" + sceneIndex.ToString());
        GUI.Label(new Rect(20, 100, 500, 500), text);
    }
}
