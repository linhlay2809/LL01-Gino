using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    public string nextScene;

    private string KEY_DATA = "unitdata";

    private void Awake()
    {
        LoadUnitData();

        // Chuyển sang Scene khác sau khi load dữ liệu xong
        SceneManager.LoadScene(nextScene);
    }

    private void LoadUnitData()
    {
        //Lấy dữ liệu dạng string ở PlayerPrefs
        string s = PlayerPrefs.GetString(KEY_DATA);

        // Nếu chuỗi string null hoặc rỗng thì sẽ tạo một data mới với các giá trị mặc định
        if (string.IsNullOrEmpty(s))
        {
            UnitData.instance = new UnitData();
            return;
        }

        // Dùng JsonDotNet convert dữ liệu từ string sang object
        UnitData.instance = JsonConvert.DeserializeObject<UnitData>(s);
    }
}
