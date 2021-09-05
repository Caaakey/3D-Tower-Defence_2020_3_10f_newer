using UnityEngine;

//  NodeController
public partial class NodeManager : MonoBehaviour
{
    //  롯데리아 버거킹 맥도날드 노브랜드 맘스터치 KFC
    //  공통점 : 치킨 버거, 시그니처 메뉴

    //  단점 ?
    //  태그로 묶는다면, 하나로 묶으면 : 햄버거집
    //  라이스버거, 와퍼, 맥모닝 - 아침메뉴, 건강식, ??, 치킨
    //  병합이 잘 되어지게 구조를 잘 잡는다면 좋은 코드를 이루어낼 수 있으나
    //  규칙을 무시하는 순간 관리가 배로 복잡해진다
    //  A -> Move, B -> Attack -> partial
    //  A -> Move Attack &. 

    //  partial -> 개발자가 협업하기 쉽게, 등 다른 목적으로 설계된 것이지
    //  개별적으로 사용하는 형식이 아님!
    //  원래는 하나!
    //  '단일 원리 원칙'을 잘 지키면 엄청난 효율!

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //Node node = hit.collider.gameObject.GetComponent<Node>();
                //if (node != null) { }

                if (hit.collider.GetComponent<Node>() is Node node)
                    Select = node;
                else
                    Select = null;
            }
        }
    }

}
