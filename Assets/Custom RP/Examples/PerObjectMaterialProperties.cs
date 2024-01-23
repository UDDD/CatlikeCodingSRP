using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{
    static int 
        baseColorId = Shader.PropertyToID("_BaseColor"),
        cutoffId = Shader.PropertyToID("_Cutoff"),
        metallicId = Shader.PropertyToID("_Metallic"),
        smoothnessId = Shader.PropertyToID("_Smoothness");

    static MaterialPropertyBlock block;

    [SerializeField]
    Color baseColor = Color.white;

    [SerializeField, Range(0f, 1f)]
    float cutoff = 0.5f, metallic = 0f, smoothness = 0.5f;

    [SerializeField]
    bool isRandomColor = false;

    Renderer renderer;

    void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
        }
        if (isRandomColor)
        {
            baseColor = new Color(Random.value, Random.value, Random.value, Random.Range(0.5f, 1f));
        }
        block.SetColor(baseColorId, baseColor);
        block.SetFloat(cutoffId, cutoff);
        block.SetFloat(metallicId, metallic);
        block.SetFloat(smoothnessId, smoothness);
        renderer.SetPropertyBlock(block);
    }

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        OnValidate();
    }
}
