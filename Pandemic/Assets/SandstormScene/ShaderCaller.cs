using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCaller : MonoBehaviour
{

    Material Material;
    [SerializeField] private Camera DoctorCamera, MonsterCamera;
    public GameObject Player;
    public GameObject Obstacle;
    public GameObject Doctor;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Obstacle = GameObject.Find("Obstacle");
        Doctor = GameObject.Find("Doctor");
        Material = Obstacle.GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        Material.SetVector("_MonsterPosition", Player.transform.position);
        Material.SetVector("_DoctorPosition", Doctor.transform.position);
        Material.SetMatrix("_CameraToWorldMatrixDoctor", DoctorCamera.cameraToWorldMatrix);
        Material.SetMatrix("_CameraToWorldMatrixMonster", MonsterCamera.cameraToWorldMatrix);
    }
}
