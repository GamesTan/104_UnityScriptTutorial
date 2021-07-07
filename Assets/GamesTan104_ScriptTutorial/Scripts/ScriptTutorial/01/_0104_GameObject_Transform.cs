using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

// 增删查改

public class _0104_GameObject_Transform : MonoBehaviour {
    public GameObject Prefab;
    public GameObject obj;
    public float MoveSpeed = 0;

    public string FindName = "123";


    [Button()]
    private static void CreateGO() {
        var tempGo = new GameObject("TestName");
        tempGo.name = "MName";
        Debug.Log("Create Go name " + tempGo.name);
    }

    [Button()]
    private static void CreateDestroyGO() {
        var tempGo = new GameObject("TestName2");
        tempGo.name = "MName2";
        Debug.Log("Create Go name " + tempGo.name);
        GameObject.Destroy(tempGo);
    }

    [Button()]
    private void CreateByInstantiate() {
        if (Prefab != null) {
            obj = GameObject.Instantiate(Prefab);
        }
        else {
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
    }

    [Button()]
    private void TestGameObjectAPI() {
        TestGameObjectAPI(obj);
    }

    [Button()]
    private static void FindGoByTag() {
        var playerGo = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Find With Tag " + (playerGo?.name ?? "Can not find obj tag"));
    }

    [Button()]
    private void _____TestFindChild() {
        TestFindChild(obj.transform);
    }

    [Button()]
    private void TestTransformAPI() {
        TestTransformAPI(obj, true);
    }

    [Button()]
    private void TestTransformAPIWorld() {
        TestTransformAPI(obj, false);
    }


    public void Update() {
        UpdatePosition();
    }

    private void UpdatePosition() {
        if (MoveSpeed <= 0) return;
        float moveDist = MoveSpeed * Time.deltaTime;
        transform.position = transform.position + transform.forward * moveDist;
    }

    private void TestFindChild(Transform trans) {
        Transform tran = trans.Find(FindName);
        if (tran == null) {
            print("Can not find child ");
        }
        else {
            print("Find child " + tran.name);
        }
    }

    private void TestGameObjectAPI(GameObject obj) {
        obj.name = FindName;
        {
            // active false 不能查找
            obj.SetActive(false);
            var findGo = GameObject.Find(FindName);
            print("GameObject.Find0  " + (findGo?.name ?? " can not find"));
            obj.SetActive(true);
        }
        {
            var findGo = GameObject.Find(FindName);
            print("GameObject.Find1  " + (findGo?.name ?? " can not find"));
        }
        {
            var findGo = GameObject.Find(FindName + "__1");
            print("GameObject.Find2 " + (findGo?.name ?? " can not find"));
        }
        obj.SetActive(false);
    }

    private Transform TestTransformAPI(GameObject obj, bool isLocal = true) {
        Transform trans = obj.transform;
        trans.SetParent(transform, false);
        if (isLocal) {
            trans.localPosition = new Vector3(0, 1, 0);
        }
        else {
            trans.position = new Vector3(0, 1, 0);
        }

        //trans.localEulerAngles
        //trans.lossyScale = Vector3.back; // 只能访问不能设置
        // SetParent(null); localScale = xxx; SetParent(rawPatent);
        trans.eulerAngles = new Vector3(0, 35, 0);
        trans.localScale = new Vector3(2, 2, 2);
        PrintTransformInfo(trans);
        // trans.SetParent(null); // 脱离当前的父节点
        return trans;
    }

    private static void PrintTransformInfo(Transform trans) {
        // 打印 Transform 信息
        print("position" + trans.position);
        print("rotation" + trans.eulerAngles);
        print("scale" + trans.localScale);
    }


    [Button("", EButtonEnableMode.Playmode)]
    void TestMoveAndActive() {
        var go = obj;

        // 2 携程
        IEnumerator TestCoroutine() {
            go.SetActive(false);
            Debug.Log($" FrameCount {Time.frameCount}");
            yield return null; // 等待一帧
            yield return new WaitForSeconds(1); // 等待 时间
            go.SetActive(true);
            yield return new WaitForSeconds(1); // 等待 时间
            go.SetActive(false);
        }

        StartCoroutine(TestCoroutine());
    }

    [Button()]
    // 移除所有 测试用的Object
    void DestroyAllChildren() {
        List<Transform> trans = new List<Transform>();
        var count = transform.childCount;
        for (int i = 0; i < count; i++) {
            var tran = transform.GetChild(i);
            Debug.Log(tran.name);
        }
        
        
        foreach (Transform tran in transform) {
            trans.Add(tran);
        }

        foreach (var item in trans) {
            UnityEngine.Object.Destroy(item.gameObject);
        }

    }
}