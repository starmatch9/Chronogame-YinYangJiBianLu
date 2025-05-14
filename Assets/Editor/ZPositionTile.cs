using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "ZPositionTile", menuName = "Tiles/Z Position Tile")]
public class ZPositionTile : Tile
{
    [SerializeField] private int zPosition = 0; // Z��λ�ã�ֵԽСԽ��ǰ

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        // ������Ƭ�ı任���󣬰���Z��ƫ��
        tileData.transform = Matrix4x4.TRS(
            new Vector3(0f, 0f, zPosition), // Z��ƫ��
            Quaternion.identity,
            Vector3.one
        );
    }
}
