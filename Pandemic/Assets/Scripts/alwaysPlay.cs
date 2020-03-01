using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alwaysPlay : MonoBehaviour
{
    public string sldAnim;

    // Start is called before the first frame update
    private void Awake()
    {
        if (GetComponent<Animator>().playbackTime == 0)
        {
            GetComponent<Animator>().Play(sldAnim);
        }
    }
}