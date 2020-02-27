using UnityEngine;

[RequireComponent(typeof(Experience))]
public class DoctorProgression : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Experience>().onLevelUp += LevelUp;
    }

    private void LevelUp(uint newLevel)
    {
        switch (newLevel)
        {
            case 1:
                Debug.Log("Doctor level 1");
                break;

            case 2:
                Debug.Log("Doctor level 2");
                break;
        }
    }
}