using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class terraintestkit : MonoBehaviour
{
    // sample terrain array
    [SerializeField] private int[,,] terrain = new int[,,] {
        { {1, 1, 1, 1 }, {0, 0, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 }},
        { {1, 1, 1, 1 }, {0, 1, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 } },
        { {1, 1, 1, 1 }, {0, 0, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 } },
        { {1, 1, 1, 1 }, {0, 0, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 }, {1, 1, 1, 1 }, {0, 0, 0, 0 } }
    };

       

    

    // Start is called before the first frame update
    void Start()
    {
        Mesh terrainMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = terrainMesh;
        var marchingCubes = GetComponent<MarchingCubes>();

        marchingCubes.Initialize(1, terrain);
        marchingCubes.March();
        Debug.Log("Counting total triangles");
        Debug.Log(marchingCubes.meshReadyVertices.Count());
        Debug.Log(marchingCubes.meshReadyTriangles.Count());
        terrainMesh.vertices = marchingCubes.meshReadyVertices;
        terrainMesh.triangles = marchingCubes.meshReadyTriangles;
    }

}
