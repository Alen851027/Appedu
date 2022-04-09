using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSkillCD : MonoBehaviour
{
    public Button btn;
    public Image img;
    public Text cd;
    public GameObject cdText;
    private bool isCoolDown = false;
    public float cooldownTime = 10f;
    private float cooldownTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        cd.gameObject.SetActive(false);
        img.fillAmount = 0f;
    }

    // Update is called once per frame
    void  Update()
    {


        btn.onClick.AddListener(() => Clicked());
        if (isCoolDown)
        {
  
            ApplyCooldown();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            UseSpell();
        }

    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0.0f)
        {
            isCoolDown = false;
            cd.gameObject.SetActive(false);
            img.fillAmount = 0f;


        }
        else
        {
            cd.text = Mathf.Round(cooldownTimer).ToString();
            img.fillAmount = cooldownTimer / cooldownTime;
            cdText.SetActive(true);

        }
    }

    public void UseSpell()
    {
        if (isCoolDown)
        {
            //return false;
        }
        else
        {
            isCoolDown = true;
            cd.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;

            //return true;
        }

    }

    public void Clicked()
    {


            
    }
}
