using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public float amplitude = 1f; // Amplitudo untuk mengatur ketinggian gelombang
    public float length = 2f;    // Panjang gelombang
    public float speed = 1f;     // Kecepatan gelombang
    public float offset = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Update()
    {
        // Update offset berdasarkan waktu untuk menciptakan efek gelombang yang bergerak
        offset += Time.deltaTime * speed;
    }

    // Fungsi untuk mendapatkan ketinggian gelombang pada titik tertentu
    public float GetWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x / length + offset);
    }
}
