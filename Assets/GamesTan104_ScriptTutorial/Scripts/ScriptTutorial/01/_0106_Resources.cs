using NaughtyAttributes;
using UnityEngine;

public class _0106_Resources : MonoBehaviour {
    [Button()]
    void LoadPrefab() {
        var path = "Prefabs/Prefab";
        var prefab = Resources.Load<GameObject>(path);
        Debug.Log("Load GameObject " + path + "  " + (prefab?.name ?? " Load Failed"));
        if (prefab != null) {
            var fab = GameObject.Instantiate(prefab);
        }

        path = path + " 1";
        var prefab2 = Resources.Load<GameObject>(path);
        Debug.Log("Load GameObject " + path + "  " + (prefab2?.name ?? " Load Failed"));
    }

    [Button()]
    void LoadMaterial() {
        var path = "Materials/Mat";
        {
            var prefab = Resources.Load<Material>(path);
            Debug.Log("Load Material " + path + "  " + (prefab?.name ?? " Load Failed"));
        }
        {
            var prefab = Resources.Load<GameObject>(path);
            Debug.Log("Load GameObject " + path + "  " + (prefab?.name ?? " Load Failed"));
        }
        {
            var prefab = Resources.Load(path) as Material;
            //var prefab = Resources.Load<Material>(path);
            Debug.Log("Load UnityEngine.Object " + path + "  " + (prefab?.name ?? " Load Failed"));
        }
    }
}