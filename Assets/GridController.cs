using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridSize = 5;
    public float tileSize = 1.0f;

    private List<GameObject> tiles = new List<GameObject>();

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        float gridOffset = (gridSize - 1) * tileSize * 0.5f;

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                Vector3 tilePosition = new Vector3(x * tileSize - gridOffset, y * tileSize - gridOffset, 0);
                GameObject newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                newTile.transform.SetParent(transform);
                tiles.Add(newTile);
            }
        }
    }
}
