using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Canvas[] menus;
    
    [SerializeField] private Button buttonModifierShow;
    [SerializeField] private Button buttonModifierClose;

    [SerializeField] private Button buttonGoalsShow;
    [SerializeField] private Button buttonGoalsClose;

    [SerializeField] private Button buttonMenuShow;
    [SerializeField] private Button buttonMenuClose;

    [SerializeField] private Button buttonReset;
    [SerializeField] private Button buttonQuit;
    
    [SerializeField] private Slider sliderEquipment;
    [SerializeField] private Slider sliderFunds;
    [SerializeField] private Slider sliderStock;
    [SerializeField] private Slider sliderVolunteers;
    [SerializeField] private Slider sliderVolume;

    [SerializeField] private float smoothSpeed = 5f;

    [SerializeField] private AudioSource[] som;
    private void Start()
    { 

        buttonModifierShow.onClick.AddListener(ShowModifierWindow);
        buttonModifierClose.onClick.AddListener(HideModifierWindow);

        buttonGoalsShow.onClick.AddListener(ShowGoalsWindow);
        buttonGoalsClose.onClick.AddListener(HideGoalsWindow);

        buttonMenuShow.onClick.AddListener(ShowMenuWindow);
        buttonMenuClose.onClick.AddListener(HideMenuWindow);

        buttonQuit.onClick.AddListener(CloseGame);
        buttonReset.onClick.AddListener(ResetGame);

        sliderEquipment.value = DataScript.equipment;
        sliderFunds.value = DataScript.funds;
        sliderStock.value = DataScript.stock;
        sliderVolunteers.value = DataScript.volunteers;

        HideModifierWindow();
        HideGoalsWindow();
        HideMenuWindow();
    }

    private void Update()
    {
        sliderEquipment.value = Mathf.MoveTowards(sliderEquipment.value, DataScript.equipment, smoothSpeed * Time.deltaTime);
        sliderFunds.value = Mathf.MoveTowards(sliderFunds.value, DataScript.funds, smoothSpeed * Time.deltaTime);
        sliderStock.value = Mathf.MoveTowards(sliderStock.value, DataScript.stock, smoothSpeed * Time.deltaTime);
        sliderVolunteers.value = Mathf.MoveTowards(sliderVolunteers.value, DataScript.volunteers, smoothSpeed * Time.deltaTime);
        GameObject.Find("MusicManager").GetComponent<MusicManager>().Volume(sliderVolume.value);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void CloseGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void HideModifierWindow()
    {
        som[0].Play();
        menus[0].enabled = false;
    }

    private void ShowModifierWindow()
    {
        som[1].Play();
        menus[0].enabled = true;
    }
    private void HideGoalsWindow()
    {
        som[0].Play();
        menus[1].enabled = false;
    }

    private void ShowGoalsWindow()
    {
        som[1].Play();
        menus[1].enabled = true;
    }
    private void HideMenuWindow()
    {
        menus[2].enabled = false;
    }

    private void ShowMenuWindow()
    {
        menus[2].enabled = true;
    }

    void Pause()
    {
        Time.timeScale = 0.0f;        
    }

    void Resume()
    {
        Time.timeScale = 1.0f;        
    }
}
