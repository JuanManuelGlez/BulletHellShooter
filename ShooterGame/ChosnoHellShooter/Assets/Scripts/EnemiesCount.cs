using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesCount : MonoBehaviour
{
    private EnemyMove[] list;
    private int enemiesCount = 0;
    public TextMeshProUGUI enemiesNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        list = FindObjectsOfType<EnemyMove>();
        enemiesNum.text = $"{list.Length.ToString()}";
    }
}
