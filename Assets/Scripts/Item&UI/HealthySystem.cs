using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthySystem : MonoBehaviour
{
	public static HealthySystem Instance;
	
    //체력 관련 변수
    public Image currentHealthGlobe;
	public Text healthText;
	public float hitPoint;//현재 체력 포인트
	public float maxHitPoint; //최대 체력 포인트

	//마나 관련 변수
	public Image currentManaGlobe;
	public Text manaText;
	public float manaPoint; //현재 마나 포인트
	public float maxManaPoint; //최대 마나포인트

    //리젠 관련 변수
    public bool heal_Regenerate = true;
	public bool mana_Regenerate = true;
	public float heal_regen;
	public float mana_regen;
	private float timeleft = 0.0f;	// Left time for current interval
	public float regenUpdateInterval = 1f;

	//갓모드
	public bool mana_GodMode;
	public bool heal_GodMode;

	//==============================================================
	// Awake
	//==============================================================
	void Awake()
	{
		Instance = this;
    }
	
	//==============================================================
	// Start
	//==============================================================
  	void Start()
	{
        UpdateGraphics();
		timeleft = regenUpdateInterval;
    }

	//==============================================================
	// Update
	//==============================================================
	void Update ()
	{
		hitPoint = Hero1.Instance.healthpoint;
		manaPoint = Hero1.Instance.manaPoint;
		maxManaPoint = Hero1.Instance.maxManaPoint;
		maxHitPoint = Hero1.Instance.maxhealthPoint;

		heal_regen = Hero1.Instance.regenhit;
		mana_regen = Hero1.Instance.regemana;

        if (heal_Regenerate) //체력 리젠이 true
			heal_Regen(); //리젠 하기

		if (mana_Regenerate) //마나 리젠이 true
			mana_Regen(); //리젠하기
	}

	//==============================================================
	// Regenerate Health & Mana
	//==============================================================
	private void mana_Regen() //마나 리젠 함수
	{
		timeleft -= Time.deltaTime; //timeleft의 시간이 감소함

		if (timeleft <= 0.0) //지정된 시간 간격 만큼 시간이 다 감소했다
		{
			// Debug mode
			if(mana_GodMode) //갓모드다
			{
				RestoreMana(maxManaPoint); //최대 마나만큼 리젠
			}
			else //아니면
			{
				RestoreMana(mana_regen); //지정된 마나 리젠 값 만큼 리젠			
			}

			UpdateGraphics(); //업데이트

			timeleft = regenUpdateInterval; //다시 지정된 시간 간격만큼 초기화
		}
	}

	private void heal_Regen()
    {
        timeleft -= Time.deltaTime; //timeleft의 시간이 감소함

        if (timeleft <= 0.0) // 지정된 시간 간격만큼 시간이 다 감소했다
        {
            // Debug mode
            if (heal_GodMode) //갓모드라면
            {
                HealDamage(maxHitPoint); //최대 체력 만큼 힐
            }
            else //아니면
            {
                HealDamage(heal_regen); //지정된 리젠 값만큼 힐
            }

            UpdateGraphics();

            timeleft = regenUpdateInterval; //다시 지정된 시간 간격으로 초기화
        }
    }

    //==============================================================
    // Health Logic
    //==============================================================

    private void UpdateHealthGlobe() //체력 상태 업데이트 및 출력 함수
	{
		float ratio = hitPoint / maxHitPoint;
		currentHealthGlobe.rectTransform.localPosition = new Vector3(0, currentHealthGlobe.rectTransform.rect.height * ratio - currentHealthGlobe.rectTransform.rect.height, 0);
		healthText.text = hitPoint.ToString("0") + "/" + maxHitPoint.ToString("0");
	}

	public void TakeDamage(float Damage) //데미지 입는 함수
	{
		hitPoint -= Damage;
		if (hitPoint < 1)
			hitPoint = 0;

		UpdateGraphics();
	}

	public void HealDamage(float Heal) //처력 회복
	{
		hitPoint += Heal;
		if (hitPoint > maxHitPoint) 
			hitPoint = maxHitPoint;

		UpdateGraphics();
	}
	public void SetMaxHealth(float max) //최대 체력 세팅
	{
		maxHitPoint += (int)(maxHitPoint * max / 100);

		UpdateGraphics();
	}

	//==============================================================
	// Mana Logic
	//==============================================================

	private void UpdateManaGlobe() //마나 상태 업데이트 및 출력 함수
	{
		float ratio = manaPoint / maxManaPoint;
		currentManaGlobe.rectTransform.localPosition = new Vector3(0, currentManaGlobe.rectTransform.rect.height * ratio - currentManaGlobe.rectTransform.rect.height, 0);
		manaText.text = manaPoint.ToString("0") + "/" + maxManaPoint.ToString("0");
	}

	public void UseMana(float Mana) //마나 사용
	{
		manaPoint -= Mana;
		if (manaPoint < 1) // Mana is Zero!!
			manaPoint = 0;

		UpdateGraphics();
	}

	public void RestoreMana(float Mana) //마나 회복
	{
		manaPoint += Mana;
		if (manaPoint > maxManaPoint) 
			manaPoint = maxManaPoint;

		UpdateGraphics();
	}
	public void SetMaxMana(float max) //최대 마나 세팅
	{
		maxManaPoint += (int)(maxManaPoint * max / 100);
		
		UpdateGraphics();
	}

	//==============================================================
	// Update all Bars & Globes UI graphics
	//==============================================================
	private void UpdateGraphics()
	{
		UpdateHealthGlobe();
		UpdateManaGlobe();
	}
}
