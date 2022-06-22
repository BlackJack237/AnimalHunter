using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int weaponDamage =2;
    [SerializeField] private AudioClip shootClip;

    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.PlayOneShot(shootClip);   
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                hit.collider.GetComponent<Animal>().DealDamage(weaponDamage);
            }
        }
    }
}
