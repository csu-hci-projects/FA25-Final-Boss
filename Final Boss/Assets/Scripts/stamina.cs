using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerSprint))]
public class PlayerStamina : MonoBehaviour
{
    [Header("Stamina Settings")]
    public float maxStamina = 100f;         
    public float staminaDrainRate = 20f;   
    public float staminaRegenRate = 10f;   
    public float regenDelay = 1.5f;        

    [Header("UI")]
    public Slider staminaBar;              

    private PlayerSprint sprint;
    private float currentStamina;
    private float regenTimer;
    private bool isDraining;

    void Start()
    {
        sprint = GetComponent<PlayerSprint>();
        currentStamina = maxStamina;

        if(staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
        }        
    }

    void Update()
    {
        bool sprinting = Input.GetKey(KeyCode.LeftShift);

        if(sprinting && sprint.CanSprint() && currentStamina > 0f)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            regenTimer = 0f;
            isDraining = true;
        }
        else
        {
            isDraining = false;
            regenTimer += Time.deltaTime;

            if(regenTimer >= regenDelay)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
            }
        }

        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        sprint.SetSprintAllowed(currentStamina > 0f);

        if(staminaBar != null)
        {
            staminaBar.value = currentStamina;
        }
           
    }
}
