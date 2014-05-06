using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour 
{
    // Игроки участвующие в сессии (вдруг будут спектаторы)
    public Dictionary<int, GemPlayer> Players = new Dictionary<int, GemPlayer>();

    // События подключения игроков к игре (через смартфокс)
}
