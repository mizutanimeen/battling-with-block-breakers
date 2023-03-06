using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject[] prefabObj;
    public float widthIncrease = 1;
    private float limit = 4f;

    /// <summary>
    /// アイテムを生成する(ブロックの場所)
    /// </summary>
    public void CreateItem(Vector3 blockPosition)
    {
        //アイテム生成の場所をブロックの座標から取得
        var x = blockPosition.x;
        var y = blockPosition.y;
        var z = blockPosition.z;
        GameObject obj = Instantiate(prefabObj[0], new Vector3(x, y, z), Quaternion.identity);
    }
    //アイテム取得時効果
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.GetComponent<ScoreScript>().ScoreUp(1.5f);
            GameObject playerObject = GameObject.FindWithTag("Player");
            Vector2 width = playerObject.transform.localScale;
            if (width.x >= limit) return;
            width.x += widthIncrease;
            playerObject.transform.localScale = width;
            if (playerObject.transform.localScale.x > limit)
            {
                width.x = limit;
                playerObject.transform.localScale = width;
            }
        }
    }
}
