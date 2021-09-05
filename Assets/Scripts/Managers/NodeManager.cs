using UnityEngine;

//  분할 (interface, struct, class 다 가능) -> 파일 분할
//  C, C++ 에서는 코드가 점점더 많아 질 경우
//  .cpp 파일 별로 기능을 나눔
//  그래서, 하나의 헤더에 여러개의 cpp 파일을 생성해서 코딩
//  ex) 캐릭터
//  header -> 캐릭터 모든 정보
//  이동 담당.cpp
//  애니메이션 담당.cpp
//  체력, ui 연결 담당.cpp
//  등등...cpp

public partial class NodeManager : MonoBehaviour
{
    private static NodeManager m_Instance = null;
    public static NodeManager Get { get => m_Instance; }

    [SerializeField] private Node[] Nodes;
    [SerializeField] private Color m_SelectColor = Color.green;
    private Node m_Selected = null;

    public Node Select
    {
        get => m_Selected;
        set
        {
            if (m_Selected != null)
                m_Selected.MaterialColor = Color.white;

            if (value == null || m_Selected == value)
                m_Selected = null;
            else
            {
                m_Selected = value;
                m_Selected.MaterialColor = m_SelectColor;
            }
        }
    }

    private void Awake()
    {
        m_Instance = this;
    }

    public void SelectCancel()
        => Select = null;
}
