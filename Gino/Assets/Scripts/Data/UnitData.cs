using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class UnitData
{
    public float hp;
    public int level;

    private string KEY_DATA = "unitdata";

    public static UnitData instance;
    // Đặt các giá trị mặc định
    public UnitData()
    {
        hp = 100f;
        level = 1;
    }

    // Save dữ liệu
    public void Save(BaseUnit unit)
    {
        hp = unit.hp;
        level = unit.level;

        // Convert dữ liệu sang dạng string
        string s = JsonConvert.SerializeObject(this);

        // Dùng PlayerPrefs lưu dữ liệu lại
        PlayerPrefs.SetString(KEY_DATA, s);
    }
}
