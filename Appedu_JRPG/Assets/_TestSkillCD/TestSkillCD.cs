using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSkillCD : MonoBehaviour
{
    Coroutine coroutineBtn;
    //private float WaitTime;
    //public Button btn;
    //public Image img;
    //public Text cd;
    //public GameObject cdText;
    //public KeyCode GetInputBtn;
    //private bool isCoolDown = false;
    //public float cooldownTime = 10f;
    //private float cooldownTimer = 2f;
    public bool isCD;
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
        public List<Animator> Animation;
        public int BtnNumber;
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
    void  LateUpdate()
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
                UseSpell(i);
            }


        }
        foreach (var item in skillTemplates)
        {
            //if (Input.GetKeyDown(skillTemplates[i].GetInputBtn))
            //{

            //    //StopAllCoroutines();
            //    UseSpell(i);
            //    //Clicked_BTN(i);

            //}

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
                //if (isCD == false)
                //{
                Clicked_BTN(x);
                //return true;
                //}
            }
        }

    }



    IEnumerator Btn_Skill(int x) 
    {
        //PlayerContorl.instance.isPlayAnim = true;
        //PlayerContorl.instance.isPlayAnim = true;
        //if (PlayerContorl.instance.animatorinfo.IsName("Move"))
        //{
        //    PlayerContorl.instance.isPlayAnim = false;
        //}

        //PlayerContorl.instance.isPlayAnim = 1;

        yield return new WaitForSeconds(skillTemplates[x].ShowTime);
        skillTemplates[x].BtnNumber = x;
        Debug.LogError(skillTemplates[x].BtnNumber);
        skillTemplates[x].SkillObjects[0].SetActive(false);
        skillTemplates[x].SkillObjects[1].SetActive(true);
        //Btn7_GameObj.SetActive(false);
        //skillTemplates[6].SkillObjects[0].SetActive(false);
        StopCoroutine(coroutineBtn);
        //StopAllCoroutines();
    }
    public void Clicked_BTN(int x) 
    {
        Debug.LogWarning(x);
        //StopCoroutine(Btn_Skill(x));
        
        switch (x)
        {
            case 0:
                if (skillTemplates[x].BtnNumber == 0)
                {
                    PlayerContorl.instance.isPlayAnim = 1;
                    skillTemplates[x].Animation[0].Play("SkillBtn1");
                    skillTemplates[x].BtnNumber = -1;
                    skillTemplates[x].SkillObjects[0].SetActive(true);
                    skillTemplates[x].SkillObjects[1].SetActive(false);
                    StartCoroutine(Btn_Skill(x));
                }
                break;

            case 1:
                if (skillTemplates[x].BtnNumber == 1)
                {
                    PlayerContorl.instance.isPlayAnim = 1;
                    skillTemplates[x].Animation[0].Play("SkillBtn2");
                    skillTemplates[x].BtnNumber = -1;
                    skillTemplates[x].SkillObjects[0].SetActive(true);
                    skillTemplates[x].SkillObjects[1].SetActive(false);
                    StartCoroutine(Btn_Skill(x));
                }
                break;
            case 2:
                if (skillTemplates[x].BtnNumber == 2)
                {
                    PlayerContorl.instance.isPlayAnim = 1;
                    skillTemplates[x].Animation[0].Play("SkillBtn3");
                    skillTemplates[x].BtnNumber = -1;
                    skillTemplates[x].SkillObjects[0].SetActive(true);
                    skillTemplates[x].SkillObjects[1].SetActive(false);
                    StartCoroutine(Btn_Skill(x));
                }
                break;
            case 3:
                if (skillTemplates[x].BtnNumber == 3)
                {
                    PlayerContorl.instance.isPlayAnim = 1;
                    skillTemplates[x].Animation[0].Play("SkillBtn4");
                    skillTemplates[x].BtnNumber = -1;
                    skillTemplates[x].SkillObjects[0].SetActive(true);
                    skillTemplates[x].SkillObjects[1].SetActive(false);
                    StartCoroutine(Btn_Skill(x));
                }
                break;
            case 4:
                if (skillTemplates[x].BtnNumber == 4)
                {
                    PlayerContorl.instance.isPlayAnim = 1;
                    skillTemplates[x].Animation[0].Play("SkillBtn5");
                    skillTemplates[x].BtnNumber = -1;
                    skillTemplates[x].SkillObjects[0].SetActive(true);
                    skillTemplates[x].SkillObjects[1].SetActive(false);
                    StartCoroutine(Btn_Skill(x));
                }
                break;
            case 5:
                if (skillTemplates[x].BtnNumber == 5)
                {
                    PlayerContorl.instance.isPlayAnim = 1;
                    skillTemplates[x].Animation[0].Play("SkillBtn6");
                    skillTemplates[x].BtnNumber = -1;
                    skillTemplates[x].SkillObjects[0].SetActive(true);
                    skillTemplates[x].SkillObjects[1].SetActive(false);
                    StartCoroutine(Btn_Skill(x));
                }
                break;
            case 6:
                if (skillTemplates[x].BtnNumber==6) 
                { 
                    PlayerContorl.instance.isPlayAnim = 1;
                    skillTemplates[x].Animation[0].Play("SkillBtn7");
                    skillTemplates[x].BtnNumber =-1;
                    skillTemplates[x].SkillObjects[0].SetActive(true);
                    skillTemplates[x].SkillObjects[1].SetActive(false);
                    StartCoroutine(Btn_Skill(x));
                }

                break;
            default:
                break;
        }

        //Btn7_GameObj.SetActive(true);
        //StartCoroutine(Btn_Skill(x));
    }

}
