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
                GetComponent<DoctorAdrenalineBoost>().Unlock();
                Debug.Log("Doctor level 2");
                break;

            case 2:
                GetComponent<MotionSensorPlacer>().Unlock();
                Debug.Log("Doctor level 3");
                break;
        }
    }
}