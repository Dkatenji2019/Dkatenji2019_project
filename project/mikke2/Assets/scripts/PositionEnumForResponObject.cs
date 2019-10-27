using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionEnumForResponObject : MonoBehaviour {

    public PositionEnumerate positionEnumerate;
    public int RespawnPosition{ get; set; }
    private void OnValidate()
    {
        RespawnPosition = (int)positionEnumerate;
    }
    private void Awake()
    {
        RespawnPosition = (int)positionEnumerate;
    }
}
