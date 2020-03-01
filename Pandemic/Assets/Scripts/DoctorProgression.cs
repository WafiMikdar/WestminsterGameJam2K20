using UnityEngine;

[RequireComponent(typeof(Experience))]
public class DoctorProgression : MonoBehaviour
{
    [SerializeField] private FadingNotification notifier;

    [SerializeField] private string adrenalineUnlockNotification = "Adrenaline boost unlocked, press Å for a temporary speed-up";
    [SerializeField] private string sensorUnlockNotification = "Motion sensors unlocked, press Ø to place a motion sensor";

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
                notifier.CreateNotification(adrenalineUnlockNotification);
                Debug.Log("Doctor level 2");
                break;

            case 2:
                GetComponent<MotionSensorPlacer>().Unlock();
                notifier.CreateNotification(sensorUnlockNotification);
                Debug.Log("Doctor level 3");
                break;
        }
    }
}