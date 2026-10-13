using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;


public class PickupParentSystem : MonoBehaviour
{
    //stores the count of collected collectibles;
    public static int count;
    public static bool check_count;

    //displays the count to the screen
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    [Serializable]
    public class Door
    {
        public GameObject door;
        public int countRequired;

        public void CheckCountToTrigger()
        {
            if (countRequired == 0 || PickupParentSystem.count >= countRequired)
            {
                door.SetActive(false);
            }
        }
    }

    public List<Door> doors;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize count to 0
        count = 0;
        check_count = false;
        //initialize the count text
        SetCountText();
        winTextObject.SetActive(false);
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12) //this may need to be changed depending on the number of collectibles
        {
            winTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    // Update is called once per frame
    void Update()
    {
        int i;
        if (check_count)
        {
            SetCountText();
            for (i = 0; i < doors.Count; i++)
            {
                if (doors[i] != null)
                {
                    if (doors[i].door.activeSelf == true)
                    {
                        doors[i].CheckCountToTrigger();
                    }
                }
            }
        }
    }
}
