using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] private Canvas[] decisionsCanvas;

    [SerializeField] private Text textModifierEquipmentPlus;
    [SerializeField] private Text textModifierEquipmentMinus;

    [SerializeField] private Text textModifierFundsPlus;
    [SerializeField] private Text textModifierFundsMinus;

    [SerializeField] private Text textModifierStockPlus;
    [SerializeField] private Text textModifierStockMinus;

    [SerializeField] private Text textModifierVolunteersPlus;
    [SerializeField] private Text textModifierVolunteersMinus;

    [SerializeField] private Text[] textRandomModifiers;

    [SerializeField] private AudioSource[] som;

    private Canvas choiceCanvas;

    private Text chosenRandomModifier;

    private void Start()
    {
        DataScript.equipment = 5;
        DataScript.funds = 5;
        DataScript.stock = 5;
        DataScript.volunteers = 5;
        DataScript.rounds = 0;
        DataScript.failures = 0;

        DataScript.equipmentModifier = 0;
        DataScript.fundsModifier = 0;
        DataScript.stockModifier = 0;
        DataScript.volunteersModifier = 0;

        hideModifiers();
        disableCanvas();
        changeDecision();
    }

    private void Update()
    {

        DataScript.equipment = Mathf.Clamp(DataScript.equipment, 0, 10);
        DataScript.funds = Mathf.Clamp(DataScript.funds, 0, 10);
        DataScript.stock = Mathf.Clamp(DataScript.stock, 0, 10);
        DataScript.volunteers = Mathf.Clamp(DataScript.volunteers, 0, 10);

        if (DataScript.rounds >= 5)
        {
            if(DataScript.equipment < DataScript.equipmentMin)
            {
                modifierStockMinus();
            }
            else if(DataScript.equipment > DataScript.equipmentMax)
            {
                modifierStockPlus();
            }
            else
            {
                modifierStockZero();
            }
            if (DataScript.funds < DataScript.fundsMin)
            {
                modifierEquipmentMinus();
            }
            else if (DataScript.funds > DataScript.fundsMax)
            {
                modifierEquipmentPlus();
            }
            else
            {
                modifierEquipmentZero();
            }
            if (DataScript.stock < DataScript.stockMin)
            {
                modifierVolunteersMinus();
            }
            else if (DataScript.stock > DataScript.stockMax)
            {
                modifierVolunteersPlus();
            }
            else
            {
                modifierVolunteersZero();
            }
            if (DataScript.volunteers < DataScript.volunteersMin)
            {
                modifierFundsMinus();
            }
            else if (DataScript.volunteers > DataScript.volunteersMax)
            {
                modifierFundsPlus();
            }
            else
            {
                modifierFundsZero();
            }
            if(DataScript.failures > 2)
            {
                SceneManager.LoadScene("GameOverScene");
            }
            ActivateRandomModifier();
            DataScript.equipment -= 2;
            DataScript.funds -= 2;
            DataScript.stock -= 2;
            DataScript.volunteers -= 2;
            DataScript.rounds = 0;
            DataScript.failures = 0;
        }    
    }

    public void disableCanvas()
    {
        decisionsCanvas[0].enabled = false;
        decisionsCanvas[1].enabled = false;
        decisionsCanvas[2].enabled = false;
        decisionsCanvas[3].enabled = false;
        decisionsCanvas[4].enabled = false;
        decisionsCanvas[5].enabled = false;
        decisionsCanvas[6].enabled = false;
        decisionsCanvas[7].enabled = false;
        decisionsCanvas[8].enabled = false;
        decisionsCanvas[9].enabled = false;
        decisionsCanvas[10].enabled = false;
        decisionsCanvas[11].enabled = false;
    }

    public void changeDecision()
    {
        som[0].Play();
        if (choiceCanvas != null)
        {
            choiceCanvas.enabled = false;
        }
        Canvas nextCanvas = decisionsCanvas[Random.Range(0, decisionsCanvas.Length)];
        while (decisionsCanvas.Length > 1 && nextCanvas == choiceCanvas)
        {
            nextCanvas = decisionsCanvas[Random.Range(0, decisionsCanvas.Length)];
        }
        som[1].Play();
        choiceCanvas = nextCanvas;
        choiceCanvas.enabled = true;
    }

    public void modifierEquipmentPlus()
    {
        textModifierEquipmentPlus.enabled = true;
        DataScript.equipmentModifier += 1;
        DataScript.failures++;
        DataScript.equipment -= 5;
    }
    public void modifierEquipmentMinus()
    {
        textModifierEquipmentMinus.enabled = true;
        DataScript.equipmentModifier -= 1;
        DataScript.failures++;
    }

    public void modifierEquipmentZero()
    {
        textModifierEquipmentPlus.enabled = false;
        textModifierEquipmentMinus.enabled = false;
        DataScript.equipmentModifier = 0;
        DataScript.equipment -= 2; 
    }

    public void modifierFundsPlus()
    {
        textModifierFundsPlus.enabled = true;
        DataScript.fundsModifier += 1;
        DataScript.failures++;
        DataScript.funds -= 5;
    }
    public void modifierFundsMinus()
    {
        textModifierFundsMinus.enabled = true;
        DataScript.fundsModifier -= 1;
        DataScript.failures++;
    }

    public void modifierFundsZero()
    {
        textModifierFundsPlus.enabled = false;
        textModifierFundsMinus.enabled = false;
        DataScript.fundsModifier = 0;
        DataScript.funds -= 2;
    }

    public void modifierStockPlus()
    {
        textModifierStockPlus.enabled = true;
        DataScript.stockModifier += 1;
        DataScript.failures++;
        DataScript.stock -= 5;
    }
    public void modifierStockMinus()
    {
        textModifierStockMinus.enabled = true;
        DataScript.stockModifier -= 1;
        DataScript.failures++;
    }

    public void modifierStockZero()
    {
        textModifierStockPlus.enabled = false;
        textModifierStockMinus.enabled = false;
        DataScript.stockModifier = 0;
        DataScript.stock -= 2;
    }

    public void modifierVolunteersPlus()
    {
        textModifierVolunteersPlus.enabled = true;
        DataScript.volunteersModifier += 1;
        DataScript.failures++;
        DataScript.volunteers -= 5;
    }
    public void modifierVolunteersMinus()
    {
        textModifierVolunteersMinus.enabled = true;
        DataScript.volunteersModifier -= 1;
        DataScript.failures++;
    }

    public void modifierVolunteersZero()
    {
        textModifierVolunteersPlus.enabled = false;
        textModifierVolunteersMinus.enabled = false;
        DataScript.volunteersModifier = 0;
        DataScript.volunteers -= 2;
    }

    public void ActivateRandomModifier()
    {
        if (chosenRandomModifier != null)
        {
            chosenRandomModifier.enabled = false;
        }
        chosenRandomModifier = textRandomModifiers[Random.Range(0,8)];
        chosenRandomModifier.enabled = true;
        if (textRandomModifiers[0].enabled == true)
        {
            DataScript.equipmentModifier++;
        }
        else if(textRandomModifiers[1].enabled == true)
        {
            DataScript.equipmentModifier--;
        } 
        else if (textRandomModifiers[2].enabled == true)
        {
            DataScript.fundsModifier++;
        }
        else if (textRandomModifiers[3].enabled == true)
        {
            DataScript.fundsModifier--;
        } 
        else if (textRandomModifiers[4].enabled == true)
        {
            DataScript.stockModifier++;
        }
        else if (textRandomModifiers[5].enabled == true)
        {
            DataScript.stockModifier--;
        } 
        else if (textRandomModifiers[6].enabled == true)
        {
            DataScript.volunteersModifier++;
        }
        else if (textRandomModifiers[7].enabled == true)
        {
            DataScript.volunteersModifier--;
        }
    }

    public void hideModifiers()
    {
        textRandomModifiers[0].enabled = false;
        textRandomModifiers[1].enabled = false;
        textRandomModifiers[2].enabled = false;
        textRandomModifiers[3].enabled = false;
        textRandomModifiers[4].enabled = false;
        textRandomModifiers[5].enabled = false;
        textRandomModifiers[6].enabled = false;
        textRandomModifiers[7].enabled = false;


        textModifierEquipmentPlus.enabled = false;
        textModifierEquipmentMinus.enabled = false;
        textModifierFundsPlus.enabled = false;
        textModifierFundsMinus.enabled = false;
        textModifierStockPlus.enabled = false;
        textModifierStockMinus.enabled = false;
        textModifierVolunteersPlus.enabled = false;
        textModifierVolunteersMinus.enabled = false;
    }
}
