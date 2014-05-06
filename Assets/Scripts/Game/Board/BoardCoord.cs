using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class BoardCoord
{
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;

    public static readonly BoardCoord Zero = new BoardCoord(0, 0);

    public BoardCoord()
    {
    }

    public BoardCoord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public BoardCoord(BoardCoord other)
    {
        this.x = other.x;
        this.y = other.y;
    }

    public override bool Equals(object obj)
    {
        BoardCoord tcObj = obj as BoardCoord;
        if (tcObj == null)
            return false;

        return tcObj.x == x && tcObj.y == y;
    }

    public override int GetHashCode()
    {
        return x*31 +y;
    }

    public override string ToString()
    {
        return "[" + x + "," + y + "]";
    }

    public static bool operator ==(BoardCoord firstCoord, BoardCoord secondCoord)
    {
        if (((object)firstCoord) != null)
            return firstCoord.Equals(secondCoord);
        return ((object) firstCoord) == ((object) secondCoord);
    }

    public static bool operator !=(BoardCoord firstCoord, BoardCoord secondCoord)
    {
        return !(firstCoord == secondCoord);
    }
}
