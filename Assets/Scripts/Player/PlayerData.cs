using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    GameManager GM;

    public float moveSpeed = 1.5f;
    public int maxCommand = 7;
    
    void Start()
    {
        GM = GameManager.instance;
    }
}
