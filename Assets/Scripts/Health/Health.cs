using UnityEngine;

public class Health : MonoBehaviour
{
 
  [SerializeField] private float startingHealth;
  private Animator anim;
  private bool dead;


   public float currentHealth { get; private set; }
   
     private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
       
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
           anim.SetTrigger("hurt");
        }
        else
        {
           if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    
    }

   

}
