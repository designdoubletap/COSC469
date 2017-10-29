using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    public Image curHealthBar;

    private float damagePoint = 100;
    private float maxDamagePoint = 100;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = damagePoint / maxDamagePoint; //returns a value between 0 and 1

        curHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        Debug.Log(damagePoint);
    }

    public void TakeDamage(float damage)
    {
        damagePoint -= damage;
        if(damagePoint < 0)
        {
            damagePoint = 0;
            SceneManager.LoadScene(0);
        }
        UpdateHealthBar();
    }

    public void HealDamage(float heal)
    {
        damagePoint += heal;
        if (damagePoint > maxDamagePoint)
        {
            damagePoint = maxDamagePoint;
        }
        UpdateHealthBar();
    }
	
	
}
