using UnityEngine;
using UnityEngine.UI;
using  DG;
using DG.Tweening;

public class HealthBarView : MonoBehaviour // все что связано с ХП игрока
{
    [SerializeField] private Image HealthFiller; // добавляем сюда хелсБар

    private const int MAX_HEALTH = 100; // максимальное кол-во хп

    public void UpdateHealthFiller(int health)  // метод для изменения шкалы хп
    {
        float amount = health * 1f / MAX_HEALTH; // меняем по формуле
        // HealthFiller.fillAmount = amount; - либо так
        HealthFiller.DOFillAmount(amount, 0.3f); // либо через дотВин через дюрейшн
    }
}
