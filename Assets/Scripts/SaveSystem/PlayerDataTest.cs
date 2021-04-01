using UnityEngine;

[System.Serializable]
public class PlayerDataTest
{
    public float[] playerPosition;

    public PlayerDataTest(Transform player)
    {
        playerPosition = SavePosition(player.position);
    }

    private float[] SavePosition(Vector3 position)
    {
        float[] retPosition = new float[3];
        for (int i = 0; i < 3; i++)
        {
            retPosition[i] = position[i];
        }

        if (position[0] == retPosition[0])
        {
            Debug.Log("Save position");
        }
        return retPosition;
    }

    public Vector3 LoadPosition(float[] position)
    {
        Vector3 retPosition = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            retPosition[i] = position[i];
        }

        return retPosition;
    }
}