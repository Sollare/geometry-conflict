using UnityEngine;
using System.Collections;

public class GemSpawnData
{
    // Уникальный идентификатор фигуры (создается на сервере)
    public SerializableGuid instanceGuid;

    // Идентификатор ресурса фигуры (приходит с сервера)
    public SerializableGuid resourceGuid;

    // Координаты респауна
    public BoardCoord coords;

    // Идентификатор владельца (сессионный идентификатор смартфокса)
    public int userId;
}
