using UnityEngine;

public class VertexCube : MonoBehaviour
{
    public MeshRenderer m_Renderer;
    private Material m_Material;

    public Vector3 m_SampleRotation;
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Material = m_Renderer.material;

        //m_Material.SetVector("_Rotation", m_SampleRotation);

    }

    void Update()
    {
        m_Material.SetVector("_Translation", new Vector3(Mathf.Sin(Time.time) * 2, 0, 0));
        m_Material.SetVector("_Rotation", new Vector3(Time.time, Time.time, 0));
        m_Material.SetVector("_Scale", new Vector3(1 + Mathf.Sin(Time.time) * 0.5f, 1, 1));

        m_Material.SetMatrix("_ViewMatrix", Camera.main.worldToCameraMatrix);
        m_Material.SetMatrix("_ProjectionMatrix", Camera.main.projectionMatrix);
    }
}