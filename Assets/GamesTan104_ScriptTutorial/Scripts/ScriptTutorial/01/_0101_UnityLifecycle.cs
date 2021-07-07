using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _0101_UnityLifecycle : MonoBehaviour
{
    public bool isPrintInUpdate = false;
    // 初始化
    void Awake() { print("Awake"); }
    void OnEnable() { print("OnEnable"); }
    void Start() { print("Start"); }

    // 游戏逻辑
    void Update() {if(isPrintInUpdate)  print("Update"); }
    void LateUpdate() { if(isPrintInUpdate)print("LateUpdate"); }

    // 游戏退出
    private void OnDisable() { print("OnDisable"); }
    private void OnDestroy() { print("OnDestroy"); }
    private void OnApplicationQuit() { print("OnApplicationQuit"); }
}
