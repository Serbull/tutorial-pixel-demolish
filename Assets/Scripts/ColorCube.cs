using UnityEngine;

public class ColorCube : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;

    private void Awake()
    {
        ApplyColor(_color);
    }

    private void OnValidate()
    {
        ApplyColor(_color);
    }

    private void ApplyColor(Color color)
    {
        var renderer = GetComponent<MeshRenderer>();
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(propertyBlock);
    }

    public void ApplyDetouchColor()
    {
        ApplyColor(_color * 0.8f);
    }
}