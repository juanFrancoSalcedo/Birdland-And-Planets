using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    [SerializeField] private List<CanonView> Cannons = new List<CanonView>();


    private void Start()
    {
        LoadCannons();
    }

    [ContextMenu("Guardar Cannons")]
    public void SaveCannons() 
    {
        var wrapper = new CannonWrapper();

        foreach (var cannon in Cannons)
        {
            wrapper.Cannons.Add(cannon.Cannon.Copy());
        }

        CannonsDataHandler.SaveData(wrapper);
    }

    public void LoadCannons() 
    {
        var wrapper = CannonsDataHandler.LoadData();
        for (int i = 0; i < Cannons.Count; i++)
        {
            Cannons[i].Cannon = wrapper.Cannons[i].Copy();
        }
    }
}

public enum Rasgo 
{
    Abordador,
    Arquero,
    Pescador,
    CofaCarajo,
    Timonel,
    Energizador,
    Artillero,
    Hunter
}

public class TripulantesDataHandler
{
    private static string filePath => Path.Combine(Application.persistentDataPath, "tripulantes.json");

    public static void SaveData(WrapperTripulanteRef dataToSave)
    {
        try
        {
            string jsonToSave = JsonUtility.ToJson(dataToSave, true);

            File.WriteAllText(filePath, jsonToSave);

            Debug.Log("Datos guardados en: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al guardar los datos: " + e.Message);
        }
    }

    public static WrapperTripulanteRef LoadData()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("No se encontró el archivo de guardado. Se devolverán datos predeterminados.");
            return new WrapperTripulanteRef(); // Retorna un nuevo objeto con valores por defecto
        }

        try
        {
            string jsonToLoad = File.ReadAllText(filePath);

            WrapperTripulanteRef loadedData = JsonUtility.FromJson<WrapperTripulanteRef>(jsonToLoad);

            Debug.Log("Datos cargados desde: " + filePath);
            return loadedData;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al cargar los datos: " + e.Message);
            return new WrapperTripulanteRef();
        }
    }
}


public class CannonsDataHandler
{
    private static string filePath => Path.Combine(Application.persistentDataPath, "cannons.json");

    public static void SaveData(CannonWrapper dataToSave)
    {
        try
        {
            string jsonToSave = JsonUtility.ToJson(dataToSave, true);

            // Escribimos el JSON en el archivo
            File.WriteAllText(filePath, jsonToSave);

            Debug.Log("Datos guardados en: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al guardar los datos: " + e.Message);
        }
    }

    public static CannonWrapper LoadData()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("No se encontró el archivo de guardado. Se devolverán datos predeterminados.");
            return new CannonWrapper(); // Retorna un nuevo objeto con valores por defecto
        }

        try
        {
            string jsonToLoad = File.ReadAllText(filePath);

            CannonWrapper loadedData = JsonUtility.FromJson<CannonWrapper>(jsonToLoad);

            Debug.Log("Datos cargados desde: " + filePath);
            return loadedData;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al cargar los datos: " + e.Message);
            return new CannonWrapper(); 
        }
    }
}
