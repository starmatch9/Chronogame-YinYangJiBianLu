using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "ZPositionTile", menuName = "Tiles/Z Position Tile")]
public class ZPositionTile : Tile
{
    [SerializeField] private int zPosition = 0; // Z轴位置，值越小越靠前

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        // 设置瓦片的变换矩阵，包含Z轴偏移
        tileData.transform = Matrix4x4.TRS(
            new Vector3(0f, 0f, zPosition), // Z轴偏移
            Quaternion.identity,
            Vector3.one
        );
    }
}
