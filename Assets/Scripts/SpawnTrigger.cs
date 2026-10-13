using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [Serializable]
    public class SetSpawn
    {
        public GameObject gameObjectToSpawn;
        public bool setActiveTo;
    }
    public List<SetSpawn> setSpawns;
    int i;

    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        for (i = 0; i < setSpawns.Count; i++)
        {
            setSpawns[i].gameObjectToSpawn.SetActive(setSpawns[i].setActiveTo);
        }
    }
}
