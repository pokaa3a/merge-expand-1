using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public partial class Tile
{
    public Vector2Int rc { get; private set; }
    public GameObject gameObject;
    public List<MapUnit> objects = new List<MapUnit>();
    private Component component;

}

public partial class Tile
{
    public Tile(Vector2Int rc)
    {
        this.rc = rc;
        gameObject = GameObject.Find($"{ObjectPath.tile}_{rc.x}_{rc.y}");
        if (gameObject == null)
        {
            gameObject = new GameObject();
            gameObject.name = $"ObjectPath.tile_{rc.x}_{rc.y}";
        }
        gameObject.transform.position = Map.Instance.RCtoXY(rc);

        if (gameObject.GetComponent<BoxCollider2D>() == null)
            gameObject.AddComponent<BoxCollider2D>();

        component = gameObject.AddComponent<Component>() as Component;
        component.tile = this;
    }

    public void Click()
    {

    }

    public Block AddBlockToTile(BlockColor color, BlockDirection direction, int number)
    {
        Block block = new Block(rc, color, direction, number);
        block.gameObject.transform.SetParent(gameObject.transform);
        block.gameObject.transform.SetAsFirstSibling();
        block.gameObject.transform.localPosition = Vector2.zero;

        return block;
    }
}

public partial class Tile
{
    private class Component : MonoBehaviour
    {
        public Tile tile;

        void OnMouseDown()
        {
            tile.Click();
        }
    }
}