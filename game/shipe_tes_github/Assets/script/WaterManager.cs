using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Vector3 waterScale;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        waterScale = transform.localScale; // Ambil skala dari objek air
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            float scaledX = transform.position.x + vertices[i].x * waterScale.x; // Pertimbangkan skala objek air
            vertices[i].y = WaveManager.instance.GetWaveHeight(scaledX);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}
