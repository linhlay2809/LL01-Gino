
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public float hp;
    public int level;
    private void Start()
    {
        LoadData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnitData.instance.Save(this);
            Debug.Log("Saved");
        }
    }
    private void LoadData()
    {
        // Gán giá trị từ GameData
        hp = UnitData.instance.hp;
        level = UnitData.instance.level;
    }
}
