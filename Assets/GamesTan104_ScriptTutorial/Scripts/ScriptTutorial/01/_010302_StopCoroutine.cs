using System.Collections;
using NaughtyAttributes;
using UnityEngine;

public class _010302_StopCoroutine : MonoBehaviour {
    private Coroutine lastCoroutine;

    [Button()]
    void TestCoroutine() {
        lastCoroutine = StartCoroutine(_TestCoroutine());
    }

    [Button()]
    void StopAllTargetCoroutine() {
        StopAllCoroutines();
    }

    [Button()]
    void StopTargetCoroutine() {
        if (lastCoroutine == null) return;
        StopCoroutine(lastCoroutine);
        lastCoroutine = null;
    }

    IEnumerator _TestCoroutine() {
        Debug.Log($"{Time.timeSinceLevelLoad}  FrameCount {Time.frameCount}");
        yield return null; // 等待一帧
        Debug.Log($"{Time.timeSinceLevelLoad}  FrameCount {Time.frameCount}");
        yield return new WaitForSeconds(1); // 等待 时间
        Debug.Log($"{Time.timeSinceLevelLoad}  FrameCount {Time.frameCount}");
        for (int i = 0; i < 3; i++) {
            yield return new WaitForSeconds(1); // 等待 时间
            Debug.Log($"{Time.timeSinceLevelLoad}  FrameCount {Time.frameCount}");
        }
        yield break; // yield 表示 结束
        for (int i = 0; i < 3; i++) {
            yield return new WaitForSeconds(1); // 等待 时间
            Debug.Log($"---:  {Time.timeSinceLevelLoad}  FrameCount {Time.frameCount}");
        }
    }
}