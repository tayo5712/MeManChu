using StarterAssets;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public ThirdPersonController character; // 캐릭터 스크립트를 가지고 있는 오브젝트
    public Slider slider; // Slider UI 요소

    // 체력바 초기화
    void Start()
    {
        slider.maxValue = character.maxHealth;
        slider.value = character.maxHealth;
    }

    // 체력바 갱신
    void Update()
    {
        slider.value = character.currentHealth;
    }
}
