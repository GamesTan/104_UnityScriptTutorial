using System;
using UnityEngine;

namespace GamesTan.Tutorial104 {
    public class _0301_CreateMeshByCode : MonoBehaviour {
        public float colorFactor;
        public Color color;

        public Shader __shader;
        public void Start() {
            Debug.Log("Start");
            var go = new GameObject("AutoGenMesh");
            var mesh = new Mesh();
            //  3-------2
            //  |     / |
            //  |  /    |
            //  0-------1
            mesh.vertices = new Vector3[4] {
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(1,1,0),
                new Vector3(0,1,0),
            };
            mesh.triangles = new int[] {
                0,2,1,
                0,3,2
            };
            //mesh.uv;
            //mesh.colors;
            //mesh.normals;
            // color normal uv ....
            mesh.RecalculateNormals();
            
            var filter = go.AddComponent<MeshFilter>();
            filter.mesh = mesh;

            // 创建材质球
            // // 1. 找 shader
            var shader = Shader.Find("GamesTan/104/_0301_TestShader");
            var mat = new Material(shader);
            // // 2. 设置属性
            var id = Shader.PropertyToID("_FloatVal");
            mat.SetFloat(id, colorFactor);        // 
            mat.SetColor("_MainColor", color); // 调整shader里面的值
            mat.EnableKeyword("_NOT_USE_MY_COLOR"); // 设置宏
            
            // renderer 
            var renderer = go.AddComponent<MeshRenderer>();
            renderer.material = mat;
        }

    }
}