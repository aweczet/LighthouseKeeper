using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] playerPosition;

    public PlayerData(Transform player)
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