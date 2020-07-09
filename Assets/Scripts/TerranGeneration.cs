using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerranGeneration : MonoBehaviour
{
    public int depth = 20;

    public int width = 256;
    public int heigth = 256;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;


    void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }
    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, heigth);

        terrainData.SetHeights(0, 0, GenerateHeigths());

        return terrainData;
    }

    float[,] GenerateHeigths()
    {
        float[,] heigths = new float[width, heigth];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                heigths[x, y] = CalculateHeigth(x, y);
            }
        }

        return heigths;
    }

    float CalculateHeigth(int x, int y)
    {
        float XCoord = (float)x / width * scale + offsetX;
        float YCoord = (float)y / heigth * scale + offsetY;

        return Mathf.PerlinNoise(XCoord,YCoord);
    }
}
