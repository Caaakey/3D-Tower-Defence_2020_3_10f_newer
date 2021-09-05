using UnityEngine;
using UnityEngine.UI;

public class PlayerInfomation : MonoBehaviour
{
    //  Singleton Design 공부해보기!
    private static PlayerInfomation m_Instance = null;
    public static PlayerInfomation Get
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<PlayerInfomation>();

                if (m_Instance == null)
                {
                    m_Instance = new GameObject("Player Infomation")
                                    .AddComponent<PlayerInfomation>();

                    DontDestroyOnLoad(m_Instance.gameObject);
                }
            }

            return m_Instance;
        }
    }

    [SerializeField] private int m_Life = 20;
    [SerializeField] private Slider m_LifeSlider;

    [SerializeField] private Text m_MoneyText;
    [SerializeField] private int m_Money = 100;
    public int Money
    {
        get => m_Money;
        set
        {
            m_Money = value;
            m_MoneyText.text = $"Gold : {m_Money}";
        }
    }


}