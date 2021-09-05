using UnityEngine;

public class Node : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;

    public bool IsUsed { get; set; } = false;
    public Color MaterialColor
    {
        get => m_MeshRenderer.material.color;
        set => m_MeshRenderer.material.color = value;
    }

    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

}