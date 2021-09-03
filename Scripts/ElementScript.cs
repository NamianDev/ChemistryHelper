using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElementScript : MonoBehaviour
{
    public TextAsset txtAsset;

    public Text Name;
    public Text Body;

    int currentID = 1;

    public int CurrentID
    {
        get
        {
            return currentID;
        }

        set 
        {
            if (value < 1)
            {
                currentID = 1;
            }
            else if (value > 18)
            {
                currentID = 18;
            }
            else
            {
                currentID = value;
            }
        }
    }

    void Start()
    {
        Debug.Log(this.name);
        txtAsset = (TextAsset)Resources.Load(("ElementsJson"), typeof(TextAsset));

        ReadElement(1, txtAsset);
    }

    public void ReadElement(int CurrentID, TextAsset txtAsset)
    {
        string ElementChildrenJson = JsonHelper.GetJsonObject(txtAsset.text, CurrentID.ToString() + "_Element"); //Спаршенный json
        Element ElementJson = JsonUtility.FromJson<Element>(ElementChildrenJson);

        string subgroup; //A - главная, B - побочная
        string Oxide;
        string LVS;
        string Charge = "+" + CurrentID.ToString();
        string Type;


        if (ElementJson.Subgroup == "A")
        {
            subgroup = "Главная подгруппа";
        }
        else
        {
            subgroup = "Побочная подгруппа";
        }

        switch (ElementJson.Group)
        {
            case 1:
                Oxide = ElementJson.Designation + "2O";
                break;
            case 2:
                Oxide = ElementJson.Designation + "O";
                break;
            case 3:
                Oxide = ElementJson.Designation + "2O3";
                break;
            case 4:
                Oxide = ElementJson.Designation + "O2";
                break;
            case 5:
                Oxide = ElementJson.Designation + "2O5";
                break;
            case 6:
                Oxide = ElementJson.Designation + "O3";
                break;
            case 7:
                Oxide = ElementJson.Designation + "2O7";
                break;
            case 8:
                Oxide = ElementJson.Designation + "O4";
                break;
            default:
                Oxide = "---";
                break;
        } //Создание оксида

        if(CurrentID == 8)
        {
            Oxide = "---";
        } //Кислородд не образует оксид

        switch (ElementJson.Group)
        {
            case 4:
                LVS = ElementJson.Designation + "H4";
                break;
            case 5:
                LVS = ElementJson.Designation + "H3";
                break;
            case 6:
                LVS = ElementJson.Designation + "H2";
                break;
            case 7:
                LVS = ElementJson.Designation + "H";
                break;

            default:
                LVS = "---";
                break;
        }//Создание ЛВС
        if(CurrentID == 1)
        {
            LVS = "---";
        } //Водород не образует ЛВС


        switch (ElementJson.period)
        {
            case 1:
                Charge += " )";
                break;
            case 2:
                Charge += " ))";
                break;
            case 3:
                Charge += " )))";
                break;
            case 4:
                Charge += " ))))";
                break;
            case 5:
                Charge += " )))))";
                break;
            case 6:
                Charge += " ))))))";
                break;
            case 7:
                Charge += " )))))))";
                break;
        } //Определение заряда

        if (!ElementJson.Amorphous)
        {
            if (ElementJson.Group == 1 || ElementJson.Group == 2)
            {
                Type = "Металл";
            }
            else if (ElementJson.Group == 8)
            {
                Type = "Инертный газ";
            }
            else
            {
                Type = "Неметалл";
            }
        } //Определение типа элемента
        else
        {
            Type = "Амфотерное вещество";
        }



          

        Name.text = "--" + ElementJson.Designation + "--\r\n" + ElementJson.Name;

        Body.text = "Порядковый номер:" + CurrentID
            + "\r\nAr(" + ElementJson.Designation + "):" + ElementJson.Atomic_mass
            + "\r\nГруппа:" + ElementJson.Group
            + "\r\nПериод:" + ElementJson.period
            + "\r\n" + subgroup
            + "\r\nВысший оксид:" + Oxide
            + "\r\nЛВС:" + LVS
            + "\r\n" + Charge
            + "\r\n" + (Mathf.Round(ElementJson.Atomic_mass) - CurrentID) + "n " + CurrentID + "e-"
            + "\r\n" + Type;

    }
}
