using StarterAssets;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public ThirdPersonController character; // ĳ���� ��ũ��Ʈ�� ������ �ִ� ������Ʈ
    public Slider slider; // Slider UI ���

    // ü�¹� �ʱ�ȭ
    void Start()
    {
        slider.maxValue = character.maxHealth;
        slider.value = character.maxHealth;
    }

    // ü�¹� ����
    void Update()
    {
        slider.value = character.currentHealth;
    }
}
