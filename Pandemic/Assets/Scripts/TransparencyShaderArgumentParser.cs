using UnityEngine;

public class TransparencyShaderArgumentParser : MonoBehaviour
{
    [SerializeField] private Material[] shaderInstances;

    [SerializeField] private Transform monsterTransform, doctorTransform;

    private void Update()
    {
        foreach (Material material in shaderInstances)
        {
            material.SetVector("_MonsterPosition", monsterTransform.position);
            material.SetVector("_DoctorPosition", doctorTransform.position);
        }
    }
}