using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    [SerializeField] private List<double> levelRequirements = new List<double>();

    [SerializeField] private Image experienceBar;

    private double XP, minXP;

    /// <summary>
    /// New level is passed
    /// </summary>
    public Action<uint> onLevelUp;

    private void Awake()
    {
        if (levelRequirements.Count < 1)
        {
            Debug.LogError($"No levels defined for: {gameObject.name} ({GetInstanceID()})");
            enabled = false;
            return;
        }
    }

    public void AwardXP(double amount)
    {
        XP += amount;
        XP = Math.Max((float)XP, (float)minXP);
        experienceBar.fillAmount = (float)(XP / levelRequirements[levelRequirements.Count - 1]);
        //Debug.Log($"XP: {XP}");
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        for (int i = 0; i < levelRequirements.Count; i++)
        {
            if (levelRequirements[i] > minXP && XP >= levelRequirements[i])
            {
                onLevelUp?.Invoke((uint)i + 1);
                minXP = levelRequirements[i];
                Debug.Log($"Level {i + 1}");
                break;
            }
        }
    }
}