using UnityEngine;

public class Player : MonoBehaviour
{
    public InventorySO inventory;
    public InventoryUI inventoryUI;
    public PlayerControls playerControls;
    private Animator anim;
    public HealthSystemUI healthBar;
    [SerializeField]
    private GameObject inventoryToggleIcon;

    public float maxHealth = 200, initialHungerState = 100, initialThirstState = 100, healthReducer = 1f;
    public float health, hunger, thirst, hungerIncreaseAmount = 2f, thirstIncreaseAmount = 3f;
    public bool isConsuming = false, isDead = false, interact = false, hasPicked = false;

    private float decreaseHungerBy = 10f;
    private float decreaseThirstBy = 20f;
    private float increaseHealthBy = 7f;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.playerMovementMap.Interact.performed += ctx => interact = true;
        playerControls.playerMovementMap.Interact.canceled += ctx => interact = false;
    }


    void Start()
    {
        anim = GetComponent<Animator>();

        health = maxHealth;
        hunger = initialHungerState;
        thirst = initialThirstState;

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetMaxHunger(hunger);
        healthBar.SetMaxThirst(thirst);
    }

    private void OnTriggerStay(Collider other)
    {
        inventoryToggleIcon.SetActive(true);
        if (interact)
        {

            Items obj = other.GetComponent<Items>();
            if (obj)
            {
                hasPicked = true;
                //anim.SetTrigger("pick");
                if (inventoryUI.PickUpItem(obj))
                {
                    Destroy(other.gameObject);
                    inventoryToggleIcon.SetActive(false);
                }

                if (obj.itemObj.consumable)
                {
                    health += increaseHealthBy;
                    hunger += decreaseHungerBy;
                    thirst += decreaseThirstBy;
                }
            }
            hasPicked = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inventoryToggleIcon.SetActive(false);
    }

    void Update()
    {
        if (!isConsuming && !isDead)
        {
            healthBar.SetHealth(health);
            healthBar.SetHunger(hunger);
            healthBar.SetThirst(thirst);
            hunger -= hungerIncreaseAmount * Time.deltaTime;
            thirst -= thirstIncreaseAmount * Time.deltaTime;
            if (hunger <= 0 || thirst <= 0)
            {
                health -= healthReducer * Time.deltaTime;
                hunger = 0;
                thirst = 0;
            }
            if (health > maxHealth)
            {
                health = 100;
            }
            if (hunger > initialHungerState)
            {
                hunger = initialHungerState;
            }
            if (thirst > initialThirstState)
            {
                thirst = initialThirstState;
            }
        }
        if (health <= 0)
        {
            died();
        }
    }


    void died()
    {
        isDead = true;
        Debug.Log("You have died!!");
        anim.SetTrigger("dead");
        GetComponent<PlayerMovement>().MovementStopped();
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
