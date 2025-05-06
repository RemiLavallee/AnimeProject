using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Enemy
{
    public class EnemyStatusBar : MonoBehaviour
    {
        [SerializeField] private Enemy enemyData;
        [SerializeField] private Image fillImage;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Update()
        {
            if (_slider.value <= _slider.minValue)
            {
                fillImage.enabled = false;
            }
            else if (_slider.value > _slider.minValue && !fillImage.enabled)
            {
                fillImage.enabled = true;
            }
            
            var fillValue = enemyData.CurrentHealth / enemyData.MaxHealth;
            _slider.value = fillValue;
        }
    }
}
