using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int LevelNo;
    public string LevelNoText;

    public SaveData(Save save)
    {
        LevelNo = save.LevelNo;
        LevelNoText = save.LevelNoText;
    }
}
