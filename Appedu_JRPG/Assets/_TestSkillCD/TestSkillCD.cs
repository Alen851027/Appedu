using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSkillCD : MonoBehaviour
{
    //private float WaitTime;
    //public Button btn;
    //public Image img;
    //public Text cd;
    //public GameObject cdText;
    //public KeyCode GetInputBtn;
    //private bool isCoolDown = false;
    //public float cooldownTime = 10f;
    //private float cooldownTimer = 2f;

    [SerializeField]
    private List<SkillTemplate> skillTemplates;

    //[SerializeField]
    //private GameObject Btn7_GameObj;
    //[SerializeField]
    //private Button Btn7;

    [System.Serializable]
    public class SkillTemplate
    {
        public Text cd;
        public GameObject cdText;
        public Image img;
        public KeyCode GetInputBtn;
        public bool isCoolDown = false;
        public float CooldownTime = 10f;
        [HideInInspector]
        public float CooldownTimer = 2f;
        public float ShowTime;
        public Button Skill;
        public List<GameObject> SkillObjects;


    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < skillTemplates.Count; i++)
        {
           skillTemplates[i].cd.gameObject.SetActive(false);
           skillTemplates[i].img.fillAmount = 0f;
        }


    }

    // Update is called once per frame
    void  Update()
    {


        //foreach (var i in skillTemplates)
        //{
        //   i.Skill.onClick.AddListener(() => Clicked_BTN(skillTemplates[i]));
        //}
        //btn.onClick.AddListener(() => Clicked());
        for (int i = 0; i < skillTemplates.Count; i++)
        {
            if (skillTemplates[i].isCoolDown)
            {

                ApplyCooldown(i);
            }

            if (Input.GetKeyDown(skillTemplates[i].GetInputBtn)) 
            {
                //StopAllCoroutines();
                UseSpell(i);
                //Clicked_BTN(i);
            }
            
        }
        ////Btn7.onClick.AddListener(() => Clicked_BTN7());
        //for (int i = 0; i < skillTemplates.Count; i++)
        //{
            
        //}
        //skillTemplates[6].Skill.onClick.AddListener(() =>Clicked_BTN7());

    }

    void ApplyCooldown(int x)
    {
        //for (int i = 0; i < skillTemplates.Count; i++)
        {

            skillTemplates[x].CooldownTimer -= Time.deltaTime;
            if (skillTemplates[x].CooldownTimer < 0.0f)
            {
                skillTemplates[x].isCoolDown = false;
                skillTemplates[x].cd.gameObject.SetActive(false);
                skillTemplates[x].img.fillAmount = 0f;


            }
            else
            {
                skillTemplates[x].cd.text = Mathf.Round(skillTemplates[x].CooldownTimer).ToString();
                skillTemplates[x].img.fillAmount = skillTemplates[x].CooldownTimer/skillTemplates[x].CooldownTime;
                skillTemplates[x].cdText.SetActive(true);

            }
        }
    }

    public void UseSpell(int x)
    {
        //for (int i = 0; i < skillTemplates.Count; i++)
        {
            if (skillTemplates[x].isCoolDown)
            {

                //return false;
            }
            else
            {
                skillTemplates[x].isCoolDown = true;
                skillTemplates[x].cd.gameObject.SetActive(true);
                skillTemplates[x].CooldownTimer = skillTemplates[x].CooldownTime;
                Clicked_BTN(x);
                //return true;
            }
        }

    }

    public void Clicked()
    {


            
    }


    IEnumerator Btn_Skill(int x) 
    {
        yield return new WaitForSeconds(skillTemplates[x].ShowTime);
        //Btn7_GameObj.SetActive(false);
        skillTemplates[6].SkillObjects[0].SetActive(false);
        StopAllCoroutines();
    }
    public void Clicked_BTN(int x) 
    {
        Debug.LogWarning(x);
        //StopCoroutine(Btn_Skill(x));
        
        switch (x)
        {
            case 0:
                break;

            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            case 6:
                skillTemplates[x].SkillObjects[0].SetActive(true);

                break;
            default:
                break;
        }

        //Btn7_GameObj.SetActive(true);
        StartCoroutine(Btn_Skill(x));
    }

}
