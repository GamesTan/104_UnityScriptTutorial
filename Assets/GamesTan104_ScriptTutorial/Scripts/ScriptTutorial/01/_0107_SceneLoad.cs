using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _0107_SceneLoad : MonoBehaviour {
    [ReorderableList] public List<string> allScenes = new List<string>();

    public LoadSceneMode LoadSceneMode = LoadSceneMode.Single;

    [Button()]
    public void LoadScene0() => LoadScene(0);

    [Button()]
    public void LoadScene1() => LoadScene(1);

    [Button()]
    public void LoadScene2() => LoadScene(2);

    [Button()]
    public void UnLoadScene0() => UnLoadScene(0);

    [Button()]
    public void UnLoadScene1() => UnLoadScene(1);

    [Button()]
    public void UnLoadScene2() => UnLoadScene(2);
    
    public void UnLoadScene(int idx) {
        SceneManager.UnloadSceneAsync(allScenes[idx]);
    }

    public void LoadScene(int idx) {
        SceneManager.LoadScene(allScenes[idx], LoadSceneMode);
        //SceneManager.LoadSceneAsync()
    }


    [Button("", EButtonEnableMode.Playmode)]
    private void DontDestroySelf() {
        Debug.Log("Dont destroy self");
        GameObject.DontDestroyOnLoad(gameObject);
    }
}