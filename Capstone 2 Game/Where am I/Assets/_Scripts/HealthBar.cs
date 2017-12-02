using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    public Image curHealthBar;
    public GameObject overlayMngr;
    GameObject pCam;

    public float damagePoint = 100;
    private float maxDamagePoint = 100;

    private void Start()
    {
        UpdateHealthBar();
        pCam = this.transform.FindChild("Player Cam").gameObject;
    }

    private void UpdateHealthBar()
    {
        float ratio = damagePoint / maxDamagePoint; //returns a value between 0 and 1

        curHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

       //Debug.Log((Mathf.Round(damagePoint * 100f / 100f)));
        
    }

    public void TakeDamage(float damage)
    {
        damagePoint -= damage;
        if(damagePoint < 0)
        {
            damagePoint = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            pCam.GetComponent<CameraShake>().shake = false;
            overlayMngr.GetComponent<Overlay>().Death();
            
        }
        UpdateHealthBar();
    }

    private void HealDamage(float heal)
    {
        damagePoint += heal;
        if (damagePoint > maxDamagePoint)
        {
            damagePoint = maxDamagePoint;
        }
        UpdateHealthBar();
    }
	
	
}
