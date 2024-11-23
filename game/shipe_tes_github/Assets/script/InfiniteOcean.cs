using UnityEngine;

public class InfiniteOcean : MonoBehaviour
{
    public Transform player;         // Player's transform
    public GameObject waterTilePrefab; // Prefab for water tiles
    public int tileSize = 10;        // Size of each water tile
    public int tilesVisible = 5;     // Number of tiles visible around the player

    private GameObject[,] waterTiles;

    void Start()
    {
        waterTiles = new GameObject[tilesVisible * 2, tilesVisible * 2];

        // Initialize the grid of water tiles
        for (int x = 0; x < tilesVisible * 2; x++)
        {
            for (int z = 0; z < tilesVisible * 2; z++)
            {
                Vector3 tilePosition = new Vector3((x - tilesVisible) * tileSize, 0, (z - tilesVisible) * tileSize);
                waterTiles[x, z] = Instantiate(waterTilePrefab, tilePosition, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        Vector3 playerPosition = new Vector3(Mathf.Floor(player.position.x / tileSize) * tileSize, 0, Mathf.Floor(player.position.z / tileSize) * tileSize);

        // Move tiles based on player's position
        for (int x = 0; x < tilesVisible * 2; x++)
        {
            for (int z = 0; z < tilesVisible * 2; z++)
            {
                Vector3 tilePosition = new Vector3((x - tilesVisible) * tileSize + playerPosition.x, 0, (z - tilesVisible) * tileSize + playerPosition.z);
                waterTiles[x, z].transform.position = tilePosition;
            }
        }
    }
}
