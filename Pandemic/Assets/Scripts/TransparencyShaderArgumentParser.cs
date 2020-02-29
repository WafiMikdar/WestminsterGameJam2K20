using UnityEngine;
using System.Linq;

public class TransparencyShaderArgumentParser : MonoBehaviour
{
    [SerializeField] private Renderer[] renderers;
    private Material[] materialInstances;

    [SerializeField] private Transform monsterTransform, doctorTransform;

    private void Awake()
    {
        materialInstances = renderers.Select(r => r.material).ToArray();
    }

    private void Update()
    {
        foreach (Material material in materialInstances)
        {
            material.SetVector("_MonsterPosition", monsterTransform.position);
            material.SetVector("_DoctorPosition", doctorTransform.position);
        }
    }
}