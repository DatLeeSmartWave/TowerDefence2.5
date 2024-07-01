using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour {
    public int currentIndexMap;
    public List<GameObject> map;

    public void Start() {
        currentIndexMap = RfHolder.Ins.mapControllerData.currentLevel;
        LoadResources();
        LoadMap();
    }
    public void LoadResources() {
        var unsortedMap = Resources.LoadAll<GameObject>("Level");
        map = unsortedMap.OrderBy(go => {
            int number;
            bool success = int.TryParse(go.name.Replace("Map", ""), out number);
            return success ? number : int.MaxValue;
        }).ToList();
    }

    public void LoadMap() {
        for (int i = 0; i < map.Count; i++) {
            if (i == currentIndexMap) {
                Instantiate(map[i], new Vector3(0, 0, 0), Quaternion.identity);
            } else {
                Debug.Log("Map not found");
            }
        }
    }
}