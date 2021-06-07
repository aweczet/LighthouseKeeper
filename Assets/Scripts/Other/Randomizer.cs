using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Klasa odpowiada za wylosowanie numeru w barometrze oraz ustawienie wskazówki
/// (chyba) -> w razie pytań tą klasę pisał Marko
/// </summary>

// todo: change name of class to more appropriate
public class Randomizer : MonoBehaviour
{
    [FormerlySerializedAs("losowa")] public int randomAngle;
    [FormerlySerializedAs("zmienna")] public int flagColorID;
    [FormerlySerializedAs("wskazowka")] public Transform barometerIndicator;
    
    void Awake()
    {
        randomAngle = Random.Range(0, -230) + 115;
        barometerIndicator.eulerAngles = new Vector3(0, -121, randomAngle);
        SetUpFlagColorID();
    }
    
    public void SetUpFlagColorID()
    {
        while( (randomAngle <= 74 && randomAngle >= 51) || (randomAngle <= 9 && randomAngle >= -9) || (randomAngle <= -51 && randomAngle >= -74)) {
            Awake();
        }
        if (randomAngle <= 115 && randomAngle >= 75)
        {
            flagColorID = 1; // zielony
        }
        else if (randomAngle <= 50 && randomAngle >= 10)
        {
            flagColorID = 2; // niebieski
        }
        else if (randomAngle <= -10 && randomAngle >= -50)
        {
            flagColorID = 3; // zolty
        }
        else if (randomAngle <= -75 && randomAngle >= -115)
        {
            flagColorID = 4; // czerwony
        }
        // if (randomAngle <= 90 && randomAngle >= 55)
        // {
        //     flagColorID = 1;
        // }
        // else if (randomAngle <= 55 && randomAngle >= 0)
        // {
        //     flagColorID = 2;
        // }
        // else if (randomAngle <= 0 && randomAngle >= -55)
        // {
        //     flagColorID = 3;
        // }
        // else
        // {
        //     flagColorID = 4;
        // }
    }
}
