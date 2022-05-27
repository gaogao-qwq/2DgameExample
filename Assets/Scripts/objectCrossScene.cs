using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objectCrossScene : MonoBehaviour
{
    public string targetScene;
    public GameObject PlayerToMove;
    public GameObject CameraToMove;

    //碰撞箱触发方法
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadYourScene());
        }
    }

    //协程加载场景方法
    IEnumerator LoadYourScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(PlayerToMove, SceneManager.GetSceneByName(targetScene));
        SceneManager.MoveGameObjectToScene(CameraToMove, SceneManager.GetSceneByName(targetScene));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
