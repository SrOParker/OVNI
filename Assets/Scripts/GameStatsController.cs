using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameStatsController : MonoBehaviour
{
    public string saveFile;
    public Stats stats;

    private void Awake()
    {
        saveFile = Application.dataPath + "/gameStats.json";
        
    }


    public void LoadStats()
    {
        if (File.Exists(saveFile))
        {
            string content = File.ReadAllText(saveFile);
            stats = JsonUtility.FromJson<Stats>(content);

            Debug.Log("Gold : " + stats.gold + " No-hit-blocks : " + stats.no_hit_blocks + "Total hit blocks : " + stats.total_hits_by_block);
           
        }
        else
        {
            Debug.Log("El archivo no existe");
        }

    }
    public void SaveStats()
    {
        Stats newStats = new Stats()
        {
            gold = stats.gold,
            no_hit_blocks = stats.no_hit_blocks,
            total_hits_by_block = stats.total_hits_by_block

        };

        string stringJSON =  JsonUtility.ToJson(newStats);
        File.WriteAllText(saveFile, stringJSON);
        Debug.Log("Saved");

    }
}
