using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;

public class _0102_BuildinTypes : MonoBehaviour {
    public Vector2 vec;
    public Vector3 vec3;
    public Vector2Int vecInt2;
    public Vector3Int vecInt3;

    public Color32 color32;
    public Color color;
    public Gradient gradient;
    public AnimationCurve curve;

    public bool IsPrintLog = true;

    public void Start() {
        //Debug.Log("Log");
        //Debug.LogWarning("LogWarning");
        //Debug.LogError("LogError");
        float valX = vec.x;
        int vecIntY = vecInt3.z;
        var valColorR = color.r;
        var valColorR256 = color32.r;
        print("------- Vector -------"); 
        print(vec);
        print(vec3);
        print(vecInt2);
        print(vecInt3);
        
        print("------- Color -------"); 
        print($"color.r={valColorR}   color32.r={valColorR256}");
        print(color);
        print(color32);
        
        print("------- Curve -------"); 
        PrintCurve();
        
        print("------- Gradient -------"); 
        PrintGradient();

    }

    private void PrintCurve() {
        var count = 5;
        for (int i = 0; i < count; i++) {
            Debug.Log("" + curve.Evaluate(i * 1.0f / count));
        }
    }

    private void Update() {
        if (IsPrintLog) {
            TestTimeAndLog();
        }
    }

    public float timeScale = 1;
    private void TestTimeAndLog() {
        Time.timeScale =timeScale;
        Debug.Log(Time.deltaTime);
        Debug.LogWarning(Time.frameCount);
        Debug.LogError($"time:{Time.timeSinceLevelLoad}  realtime:{Time.realtimeSinceStartup}");
    }

    [Button()]
    private void PrintGradient() {
        var alphaKeys = gradient.alphaKeys;
        foreach (var info in alphaKeys) {
            Debug.Log($"t: {info.time}a:{info.alpha}");
        }

        var colorKeys = gradient.colorKeys;
        foreach (var info in colorKeys) {
            Debug.Log($"t: {info.time}a:{info.color}");
        }

        var count = 5;
        for (int i = 0; i < count; i++) {
            Debug.Log("" + gradient.Evaluate(i * 1.0f / count));
        }
    }
}