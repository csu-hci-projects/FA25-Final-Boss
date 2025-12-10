using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Sprint))]
public class Stamina : MonoBehaviour
{
    [Header("Stamina Settings")]
    public float maxStamina = 100f;         
    public float staminaDrainRate = 20f;   
    public float staminaRegenRate = 10f;   
    public float regenDelay = 1.5f;        

    [Header("UI")]
    public Slider staminaBar;              

    private Sprint s;
    private float currentStamina;
    private float regenTimer;

    void Start()
    {
        s = GetComponent<Sprint>();
        currentStamina = maxStamina;

        if(staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
        }        
    }

    void Update()
    {
        bool sprinting = Input.GetKey(KeyCode.LeftShift);

        if(sprinting && s.CanSprint() && currentStamina > 0f)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            regenTimer = 0f;
        }
        else
        {
            regenTimer += Time.deltaTime;

            if(regenTimer >= regenDelay)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
            }
        }

        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        s.SetSprintAllowed(currentStamina > 0f);

        if(staminaBar != null)
        {
            staminaBar.value = currentStamina;
        }
           
    }
}
