using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _0103_Coroutine : MonoBehaviour {
    public float timeSinceGameStart = 0;
    public bool HasPrintHelloWorld1 = false;
    public bool HasPrintHelloWorld3 = false;

    void Update() {
        PrintWithTimer();
    }

    private void PrintWithTimer() {
        timeSinceGameStart += Time.deltaTime;
        if (timeSinceGameStart > 1) {
            if (!HasPrintHelloWorld1) {
                print("hello world 1");
                HasPrintHelloWorld1 = true;
            }
        }

        if (timeSinceGameStart > 3) {
            if (!HasPrintHelloWorld3) {
                print("hello world 3");
                HasPrintHelloWorld3 = true;
            }
        }
    }


    public bool IsUseCoroutine = false;
    void Start() {
        if (IsUseCoroutine) {
            StartCoroutine(PrintWithCoroutine());
        }
    }

    IEnumerator PrintWithCoroutine() {
        yield return new WaitForSeconds(1);
        print("hello world 1  with Coroutine");
        yield return new WaitForSeconds(2);
        print("hello world 3 with Coroutine");
    }
}