using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{
    static int baseColorId = Shader.PropertyToID("_BaseColor");
    static int cutoffId = Shader.PropertyToID("_Cutoff");

    static MaterialPropertyBlock block;

    [SerializeField]
    Color baseColor = Color.white;

    [SerializeField, Range(0f, 1f)]
    float cutoff = 0.5f;

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
        renderer.SetPropertyBlock(block);
    }

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        OnValidate();
    }
}
