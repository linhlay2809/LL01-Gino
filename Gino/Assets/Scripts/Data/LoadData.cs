using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LoadData : MonoBehaviour
{
    GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        UnitData dt = JsonUtility.FromJson<UnitData>(json);
        gm.amountKnife = dt.knife;
    }

}
