using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CardManager : MonoBehaviour
{
	
	public GameObject idCard;
	public Animator idCardAnimator;
	public GameObject idCardOpenButton;
	public GameObject idCardCloseButton;
	
	[Space]
	[Space]
	
	public GameObject studentCard;
	public Animator studentCardAnimator;
	public GameObject studentCardOpenButton;
	public GameObject studentCardCloseButton;
	
	[Space]
	[Space]
	
	public GameObject libraryCard;
	public Animator libraryCardAnimator;
	public GameObject libraryCardOpenButton;
	public GameObject libraryCardCloseButton;
	
	[Space]
	[Space]
	
	public GameObject aboutMeText;
	public GameObject aboutOpenButton;
	public GameObject aboutCloseButton;
	
	[Space]
	[Space]
	public VideoClip videoClip;
	public VideoPlayer videoPlayer;
	public GameObject tv;
	public Animator tvAnimator;
	public GameObject tvOpenButton;
	public GameObject tvCloseButton;
	
	
    // Start is called before the first frame update
    void Start()
    {
		idCard.SetActive(false);
		idCardCloseButton.SetActive(false);
		
        studentCard.SetActive(false);
		studentCardCloseButton.SetActive(false);
		
		libraryCard.SetActive(false);
		libraryCardCloseButton.SetActive(false);
		
		TriggerAboutMe(false);
		
		tv.SetActive(false);
		tvCloseButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void TriggerIDCard(bool _value)
	{
		if(_value == true)
		{
			idCard.SetActive(true);
		}
		
		idCardCloseButton.SetActive(_value);
		idCardOpenButton.SetActive(!_value);
		
		idCardAnimator.SetBool("isOpened", _value);
	}
	
	public void TriggerStudentCard(bool _value)
	{
		if(_value == true)
		{
			studentCard.SetActive(true);
		}
		
		studentCardCloseButton.SetActive(_value);
		studentCardOpenButton.SetActive(!_value);
		
		studentCardAnimator.SetBool("isOpened", _value);
	}
	
	public void TriggerLibraryCard(bool _value)
	{		
		if(_value == true)
		{
			libraryCard.SetActive(true);
		}
		
		libraryCardCloseButton.SetActive(_value);
		libraryCardOpenButton.SetActive(!_value);
		
		libraryCardAnimator.SetBool("isOpened", _value);
	}
	
	public void TriggerAboutMe(bool _value)
	{
		
		aboutMeText.SetActive(_value);
		
		aboutCloseButton.SetActive(_value);
		aboutOpenButton.SetActive(!_value);
	}
	
	public void TriggerTV(bool _value)
	{
		StartCoroutine(StartTV(_value));
	}
	
	IEnumerator StartTV(bool _value)
	{
		if(_value == false)
		{
			videoPlayer.enabled = false;
		}
		else
		{
			videoPlayer.enabled = true;
			
		}
		
		TriggerAboutMe(false);
		TriggerIDCard(false);
		TriggerLibraryCard(false);
		TriggerStudentCard(false);
		
		idCardOpenButton.SetActive(!_value);
		studentCardOpenButton.SetActive(!_value);
		libraryCardOpenButton.SetActive(!_value);
		aboutOpenButton.SetActive(!_value);
		
		yield return new WaitForSeconds(1f);
		
		if(_value)	tv.SetActive(true);
		tvAnimator.SetBool("isOpened", _value);
		
		tvOpenButton.SetActive(!_value);
		tvCloseButton.SetActive(_value);
		
		yield return new WaitForSeconds(2f);
		
		if(_value == true)
		{
			videoPlayer.clip = videoClip;
			videoPlayer.Play();
		}
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
