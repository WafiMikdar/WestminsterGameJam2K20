using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWallPlacer : SupplyDropAbility
{
    [SerializeField] private uint usesLeft;

    [SerializeField] private MonsterSfx monsterSfx;
    private float readyTime;

    [SerializeField] private LayerMask buildingLayer;

    [SerializeField] private GameObject horizontalWallPrefab, verticalWallPrefab;

    public override void TryActivate()
    {
        if (usesLeft > 0)
        {
            monsterSfx.PlaySFX(monsterSfx.MonsterSpiderWebSound);
            Activate();
            usesLeft--;
        }
    }

    public override void Activate()
    {
        (Vector2 b1, Vector2 b2, bool isHorizontal) = GetWallInfo();

        GameObject wall = Instantiate(isHorizontal ? horizontalWallPrefab : verticalWallPrefab, (b1 + b2) * 0.5f, Quaternion.identity);
        float dis = Mathf.Abs(isHorizontal ? b1.x - b2.x : b1.y - b2.y);

        SpriteRenderer wallRend = wall.GetComponent<SpriteRenderer>();
        Vector2 size = isHorizontal ? new Vector2(dis, wallRend.size.y) : new Vector2(wallRend.size.x, dis);
        wallRend.size = size;
        wall.GetComponent<BoxCollider2D>().size = size;
    }

    /// <summary>
    /// Returns border 1, border 2 and whether wall is horizontal
    /// </summary>
    /// <returns></returns>
    private (Vector2, Vector2, bool) GetWallInfo()
    {
        Vector2 upHitPos = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, buildingLayer).point;
        Vector2 rightHitPos = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, buildingLayer).point;
        Vector2 downHitPos = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, buildingLayer).point;
        Vector2 leftHitPos = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, buildingLayer).point;

        return Mathf.Abs(upHitPos.y - downHitPos.y) < Mathf.Abs(leftHitPos.x - rightHitPos.x) ? (upHitPos, downHitPos, false) : (leftHitPos, rightHitPos, true);
    }
}