using UnityEngine;
using System.Collections;

/// <summary>
/// Компонент размещается непосредственно на объекте доски
/// Содержит логику работы с сеткой
/// </summary>
public class BoardGridManager : MonoBehaviour
{
    private static BoardGridManager _board;

    // Статический инстанс для доступа к доске из других классов
    public static BoardGridManager instance
    {
        get
        {
            if (_board == null)
                _board = GameObject.FindObjectOfType<BoardGridManager>();

            return _board;
        }
    }

    /// <summary>
    /// Размер сетки
    /// </summary>
    public int sizeX = 7, sizeY = 7;

    public BoardCoord ScreenToTileCoord(Vector3 screenPos)
    {
        // Вычислить координаты доски по позиции на экране
        return new BoardCoord(0, 0);
    }

    public Vector3 GetCellCenter(BoardCoord tc)
    {
        // Вычислить координаты в пространстве по координатам на доске
        return Vector3.zero;
    }
}
