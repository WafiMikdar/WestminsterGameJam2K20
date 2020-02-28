using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class DoctorNewsBroadcast : MonoBehaviour
{
    [SerializeField] private GameObject cameraGameObject;
    public void CreateNewBroadcast()
    {
        cameraGameObject.SetActive(true);
        StartCoroutine(Duration(5));
        //cameraGameObject = (GameObject)
        //Instantiate(cameraGameObject);
        //Destroy(cameraGameObject, 5f);
    }


    IEnumerator Duration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cameraGameObject.SetActive(false);
    }

}
