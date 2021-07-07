using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class _010502_TestComponent : MonoBehaviour {
    public float val;

    public virtual void DoUpdate(float dt) {
        val += dt;
        Debug.Log($"{GetType().Name}  {transform.name}  ");
    }
}

public class _010502_TestChildComponent : _010502_TestComponent {
    public override void DoUpdate(float dt) {
        base.DoUpdate(dt);
        val += dt * 9;
    }
}


public class _0105_Component : MonoBehaviour {
    List<_010502_TestComponent> comps = new List<_010502_TestComponent>();

    public void Start() {
        name = GetType().Name;
    }

    [Button()]
    private static void FindCompByType() {
        var findCompGo = GameObject.FindObjectOfType<_0105_Component>();
        Debug.Log("Find With Tag " + (findCompGo?.name ?? "Can not find obj tag"));
    }

    [Button()]
    private void AddComp() {
        var go = new GameObject("child");
        go.transform.SetParent(transform, false);
        var comp = go.AddComponent<_010502_TestChildComponent>();
        comp.val = 0;
        comps.Add(comp);
        var comp2 = go.AddComponent<_010502_TestComponent>();
        comp2.val = 0;
        comps.Add(comp2);
    }

    [Button()]
    private void DestroyComp() {
        var comp = gameObject.GetComponentInChildren<_010502_TestComponent>();
        //GetComponentsInChildren<>
        //GetComponent
        if (comp != null) {
            UnityEngine.Object.Destroy(comp);
        }
        Debug.Log("DestroyObj");
    }


    private void Update() {
        var dt = Time.deltaTime;
        foreach (var comp in comps) {
            if (comp != null) comp.DoUpdate(dt);
        }
    }
}