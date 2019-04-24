using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    public GameObject Trash_1;
    public GameObject Trash_2;
    public GameObject Trash_3;
    public GameObject Trash_4;
    public GameObject Trash_5;
    public GameObject Trash_6;
    public GameObject Trash_7;

    public GameObject Fish_1;
    public GameObject Fish_2;
    public GameObject Fish_3;
    public GameObject Fish_4;
    public GameObject Fish_5;

    public GameObject SeaWeed;

    public GameObject HurtedFish_1;
    public GameObject HurtedFish_2;
    public GameObject HurtedFish_3;
    public GameObject HurtedFish_4;

    int ToRow, ToRow2, NowRow = 2;
    int WhichTrash, WhichFish;
    int FishCount;
    int IfFishCreate, IfTrashCreate;
    GameObject Temp,temp;
    Vector3 Pos, Pos2, Pos3;
    float WaitTime = 0.8f;

    IEnumerator Start()
    {
        while (true)
        {
            IfTrashCreate = (int)Random.Range(0, 3);
            if(IfTrashCreate<2)
            {
                TrashCreate();
            }
            IfFishCreate = (int)Random.Range(0, 8);
            if(IfFishCreate<6)
            {
                FishCreate();
            }
            yield return new WaitForSeconds(WaitTime);
        }
    }

    void TrashCreate()
    {
        do
        {
            ToRow = (int)Random.Range(1, 4);
         } while ((ToRow - NowRow == -2) || (ToRow - NowRow == 2));
        NowRow = ToRow;

        WhichTrash = (int)Random.Range(1, 8);
        Pos.x = transform.position.x;
        Pos.y = ToRow * (-2f) - 1f;
        Pos.z = 0;

        switch(WhichTrash)
        {
            case 1: Temp = Trash_1; break;
            case 2: Temp = Trash_2; break;
            case 3: Temp = Trash_3; break;
            case 4: Temp = Trash_4; break;
            case 5: Temp = Trash_5; break;
            case 6: Temp = Trash_6; break;
            case 7: Temp = Trash_7; break;
        }

        Instantiate(Temp, Pos, Quaternion.identity);

        /*if(Catch.count>3&&WaitTime==1f)
        {
            WaitTime = 0.03f;
        }
        if(Catch.count>10&&WaitTime==0.5f)
        {
            WaitTime = 0.01f;
        }
        */
        if (Catch.count < 20)
            WaitTime = 0.8f - 0.02f * Catch.count;
        else
            WaitTime = 0.35f;
    }

    void FishCreate()
    {
        FishCount = (int)Random.Range(0, 5);
        if (FishCount !=4)
        {
            do
            {
                ToRow2 = (int)Random.Range(1, 4);
            } while (ToRow2 == ToRow);

            Pos2.x = transform.position.x;
            Pos2.y = ToRow2 * (-2f) - 1f;
            Pos2.z = 0;

            WhichFish = (int)Random.Range(1, 7);
            int WhichHurtFish = (int)Random.Range(1, 5);
            switch (WhichFish)
            {
                case 1: temp = Fish_1; break;
                case 2: temp = Fish_2; break;
                case 3: temp = Fish_3; break;
                case 4: temp = Fish_4; break;
                case 5: temp = Fish_5; break;
                case 6: if (WhichHurtFish == 1) temp = HurtedFish_1;
                        else if (WhichHurtFish == 2) temp = HurtedFish_2;
                        else if (WhichHurtFish == 3) temp = HurtedFish_3;
                        else if (WhichHurtFish == 4) temp = HurtedFish_4;
                        break;                   
            }

            Instantiate(temp, Pos2, Quaternion.identity);
        }
        else if(FishCount==4)
        {
            if(ToRow2==1)
            CreateDouble();
        }
    }

    void CreateDouble()
    {
        Pos3.x = transform.position.x;
        Pos3.y = -6.43f;
        Pos3.z = 0;
        Instantiate(SeaWeed, Pos3,Quaternion.identity);
    }
}
