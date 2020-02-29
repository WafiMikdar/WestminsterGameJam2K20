//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Timer : MonoBehaviour
//{
//    private float TimeLeft = 120.0f;
//    Text Counter;
//    // Start is called before the first frame update
//    void Start()
//    {
//        Counter = GetComponent<Text>();
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        TimeLeft -= Time.deltaTime;
//        if (TimeLeft <= 0)
//        {
//            Debug.Log("GameOver");
//            enabled = false;
//        }
//        else
//            Debug.Log(TimeLeft);

//        Counter.text = Mathf.Floor(TimeLeft / 60).ToString("00") + ":" + Mathf.Floor(TimeLeft % 60).ToString("00");
//    }
//}