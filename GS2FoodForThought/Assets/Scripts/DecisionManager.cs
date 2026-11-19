using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    GameObject canvasMain;

    private void Start()
    {
        canvasMain = GameObject.Find("CanvasMain");
    }

    public void plusFundsMinusEquipment()
    {
        DataScript.funds += Random.Range(1, 4) + DataScript.fundsModifier;
        DataScript.equipment -= Random.Range(0, 4) + DataScript.equipmentModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusFundsMinusVolunteers()
    {
        DataScript.funds += Random.Range(1, 4) + DataScript.fundsModifier; 
        DataScript.volunteers -= Random.Range(0, 4) + DataScript.volunteersModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusFundsMinusStock()
    {
        DataScript.funds += Random.Range(1, 4) + DataScript.fundsModifier;
        DataScript.stock -= Random.Range(0, 4) + DataScript.stockModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusEquipmentMinusFunds() 
    {
        DataScript.equipment += Random.Range(1, 4) + DataScript.equipmentModifier;
        DataScript.funds -= Random.Range(0, 4) + DataScript.fundsModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusEquipmentMinusStock()
    {
        DataScript.equipment += Random.Range(1, 4) + DataScript.equipmentModifier;
        DataScript.stock -= Random.Range(0, 4) + DataScript.stockModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusEquipmentMinusVolunteers()
    {
        DataScript.equipment += Random.Range(1, 4) + DataScript.equipmentModifier;
        DataScript.volunteers -= Random.Range(0, 4) + DataScript.volunteersModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusVolunteersMinusFunds()
    {
        DataScript.volunteers += Random.Range(1, 4) + DataScript.volunteersModifier;
        DataScript.funds -= Random.Range(0, 4) + DataScript.fundsModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusVolunteersMinusStock()
    {
        DataScript.volunteers += Random.Range(1, 4) + DataScript.volunteersModifier;
        DataScript.stock -= Random.Range(0, 4) + DataScript.stockModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusVolunteersMinusEquipment()
    {
        DataScript.volunteers += Random.Range(1, 4) + DataScript.volunteersModifier;
        DataScript.equipment -= Random.Range(0, 4) + DataScript.equipmentModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusStockMinusFunds()
    {
        DataScript.stock += Random.Range(1, 4) + DataScript.stockModifier;
        DataScript.funds -= Random.Range(0, 4) + DataScript.fundsModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusStockMinusVolunteers()
    {
        DataScript.stock += Random.Range(1, 4) + DataScript.stockModifier;
        DataScript.volunteers -= Random.Range(0, 4) + DataScript.volunteersModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }

    public void plusStockMinusEquipment()
    {
        DataScript.stock += Random.Range(1, 4) + DataScript.stockModifier;
        DataScript.equipment -= Random.Range(0, 4) + DataScript.equipmentModifier;
        DataScript.rounds++;
        canvasMain.GetComponent<CanvasMain>().changeDecision();
    }
}
