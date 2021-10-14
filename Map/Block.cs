using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public enum BlockColor
{
    Yellow,
    Blue,
    Red,
    Green
};

public enum BlockDirection
{
    Up,
    Down,
    Left,
    Right
}

public partial class Block
{
    public Vector2Int rc;
    public BlockColor color;
    public BlockDirection direction;
    public int number;

    public GameObject gameObject;
    public GameObject colorObject;
    public GameObject numberObject;
    public GameObject directionObject;
}

public partial class Block
{
    public Block(
        Vector2Int rc,
        BlockColor color,
        BlockDirection direction,
        int number)
    {
        this.rc = rc;
        this.color = color;
        this.direction = direction;
        this.number = number;

        gameObject = new GameObject("block");

        colorObject = new GameObject("color");
        colorObject.transform.SetParent(gameObject.transform);
        Utils.SetSprite(colorObject, ColorToSpritePath(color));
        Utils.SetSpriteSortingOrder(colorObject, 1);

        directionObject = new GameObject("direction");
        directionObject.transform.SetParent(gameObject.transform);
        Utils.SetSprite(directionObject, DirectionToSpritePath(direction));
        Utils.SetSpriteSortingOrder(directionObject, 2);

        numberObject = new GameObject("number");
        numberObject.transform.SetParent(gameObject.transform);
        Utils.SetSprite(numberObject, NumberToSpritePath(number));
        Utils.SetSpriteSortingOrder(numberObject, 3);
    }

    private string ColorToSpritePath(BlockColor color)
    {
        switch (color)
        {
            case BlockColor.Blue:
                return SpritePath.Block.blue;
            case BlockColor.Yellow:
                return SpritePath.Block.yellow;
            case BlockColor.Green:
                return SpritePath.Block.green;
            case BlockColor.Red:
                return SpritePath.Block.red;
            default:
                Assert.IsTrue(false);
                break;
        }
        return SpritePath.Block.empty;
    }

    private string DirectionToSpritePath(BlockDirection direction)
    {
        switch (direction)
        {
            case BlockDirection.Up:
                return SpritePath.Block.up;
            case BlockDirection.Down:
                return SpritePath.Block.down;
            case BlockDirection.Left:
                return SpritePath.Block.left;
            case BlockDirection.Right:
                return SpritePath.Block.right;
            default:
                Assert.IsTrue(false);
                break;
        }
        return SpritePath.Block.up;
    }

    private string NumberToSpritePath(int num)
    {
        switch (num)
        {
            case 1:
                return SpritePath.Block.num1;
            case 2:
                return SpritePath.Block.num2;
            case 3:
                return SpritePath.Block.num3;
            case 4:
                return SpritePath.Block.num4;
            case 5:
                return SpritePath.Block.num5;
            case 6:
                return SpritePath.Block.num6;
            default:
                Assert.IsTrue(false);
                break;
        }
        return SpritePath.Block.num1;
    }
}