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
        randomAngle = Random.Range(0, -180) + 90;
        barometerIndicator.eulerAngles = new Vector3(0, -121, randomAngle);
        SetUpFlagColorID();
    }
    
    public void SetUpFlagColorID()
    {
        if (randomAngle <= 90 && randomAngle >= 55)
        {
            flagColorID = 1;
        }
        else if (randomAngle <= 55 && randomAngle >= 0)
        {
            flagColorID = 2;
        }
        else if (randomAngle <= 0 && randomAngle >= -55)
        {
            flagColorID = 3;
        }
        else
        {
            flagColorID = 4;
        }
    }
}
