using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class QualitySettingsSwitcher : MonoBehaviour
{
    // Asigna tus Assets de Render Pipeline (los archivos .asset URP) 
    // en el Inspector de Unity
    public UniversalRenderPipelineAsset mobileLowQuality;
    public UniversalRenderPipelineAsset mobileMidQuality;
    public UniversalRenderPipelineAsset pcQuality;

    /// <summary>
    /// Enum para definir los niveles de calidad.
    /// </summary>
    public enum QualityLevel
    {
        MobileLow,    // M�vil Baja
        MobileMedium, // M�vil Media / Decente
        PC            // PC
    }

    // Nivel de calidad actual (solo para referencia en el Inspector)
    [SerializeField]
    private QualityLevel currentQuality = QualityLevel.PC;


    private void Start()
    {
        // Puedes establecer un nivel de calidad predeterminado al inicio.
        // Por ejemplo, para dispositivos m�viles, podr�as empezar con MobileMedium.
        // SetQuality(QualityLevel.MobileMedium); 

        // O simplemente asegurarte de que la calidad configurada en Unity se aplique.
        SetQuality(currentQuality);
    }

    /// <summary>
    /// Establece el nivel de calidad especificado.
    /// </summary>
    /// <param name="level">El nivel de calidad a establecer.</param>
    public void SetQuality(QualityLevel level)
    {
        UniversalRenderPipelineAsset targetAsset = null;

        switch (level)
        {
            case QualityLevel.MobileLow:
                targetAsset = mobileLowQuality;
                break;
            case QualityLevel.MobileMedium:
                targetAsset = mobileMidQuality;
                break;
            case QualityLevel.PC:
                targetAsset = pcQuality;
                break;
            default:
                Debug.LogError("Nivel de calidad no reconocido: " + level);
                return;
        }

        if (targetAsset != null)
        {
            // Establece el asset del Render Pipeline para el nivel de calidad actual.
            // Esto solo afecta a GraphicsSettings.renderPipelineAsset.
            QualitySettings.renderPipeline = targetAsset;

            // Tambi�n puedes establecerlo globalmente para GraphicsSettings
            // para asegurar la consistencia.
            GraphicsSettings.defaultRenderPipeline = targetAsset;

            currentQuality = level;
            Debug.Log($"Calidad cambiada a: **{level}** (Asset: {targetAsset.name})");
        }
        else
        {
            Debug.LogError($"Falta el asset de Render Pipeline para el nivel: **{level}**. Asigna el asset en el Inspector.");
        }
    }

    public void SetQualityToMobileLow()
    {
        SetQuality(QualityLevel.MobileLow);
    }

    public void SetQualityToMobileMedium()
    {
        SetQuality(QualityLevel.MobileMedium);
    }

    public void SetQualityToPC()
    {
        SetQuality(QualityLevel.PC);
    }
}