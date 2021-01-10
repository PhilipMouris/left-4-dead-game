﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 

    private Animator animator;

    private Animator pistolAnimator;

    private int HP;

    //private List<Weapon> weapons =  new List<Weapon>();

    private Companion companion;

    private Gernade[] gernades;

    private RageMeter rageMeter;

    private bool isWeaponDrawn;

    private GameObject weaponCamera;

    private Vector3 rayCenter;

    IDictionary<string, GameObject> crossHairs;

    private GameObject normalInfectantInRange;

    private Weapon currentWeapon;

    private GameObject crossHair;

    private GameObject bulletHoles;

    private GameObject bulletHole;

    private GameObject collided;

    private Vector3 hitPoint;





    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(NormalInfectantConstants.TAG)){
            other.gameObject.GetComponent<NormalInfectant>().Chase();
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag(NormalInfectantConstants.TAG)){
            other.gameObject.GetComponent<NormalInfectant>().UnChase();
        }
    }
    
    
    void Awake()
    {  
        rayCenter = new Vector3(0.55F, 0.5F, 0);
        animator = GetComponent<Animator>();
        crossHairs = new Dictionary<string, GameObject>();
        InitializeCrossHairs();
        weaponCamera = GameObject.Find(PlayerConstants.WEAPON_CAMERA);
        bulletHoles = GameObject.Find(PlayerConstants.BULLET_HOLES);
        bulletHole = Resources.Load(PlayerConstants.BULLET_HOLE_PATH) as GameObject;
        Debug.Log(bulletHole.name +  "NAMEEE");
        isWeaponDrawn = false;
    }

    void FixedUpdate(){
        HandleRayCast();
      
    }

    void InitializeCrossHairs() {
        foreach(KeyValuePair<string, string> kvp in WeaponsConstants.WEAPON_TYPES) {
            //Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            GameObject currentCrossHair = GameObject.Find($"{kvp.Value}CrossHair");
            crossHairs.Add(kvp.Value, currentCrossHair);
            if(kvp.Key == "PISTOL"){
                this.crossHair = currentCrossHair;
            }
            else {
                if(currentCrossHair != null) currentCrossHair.SetActive(false);
            }
        }

    }
    
    
    void HandleRayCast() {
        if(!isWeaponDrawn) return;
        Ray ray = Camera.main.ViewportPointToRay(rayCenter);
        normalInfectantInRange = null;
        RaycastHit hit;
        // if (Physics.Raycast(ray, out hit, currentWeapon.GetRange())) {
        if (Physics.Raycast(ray, out hit, 100)) {
             hitPoint = hit.point;
             collided = hit.collider.gameObject;
             if(collided.CompareTag(NormalInfectantConstants.TAG)){
                   normalInfectantInRange = collided;
                   SetCrossHairRed();
                   return;
            }

            // Debugging
             Debug.DrawLine(ray.origin, hit.point);
        }
        SetCrossHairGreen();
    }
    
     public void HandleDrawWeapon(){
            this.isWeaponDrawn = true;
            //animator.SetBool(WeaponsConstants.DRAW_PISTOL, isWeaponDrawn);
            animator.SetTrigger($"draw{currentWeapon.GetType()}");
        }
    
    public void HandlePutDownWeapon() {
        if(Input.GetButtonDown(PlayerConstants.PUT_DOWN_WEAPON_INPUT)){
           this.isWeaponDrawn = false;
           animator.SetTrigger(PlayerConstants.SWITCH);
        }
    }
  

    private void HandleFire(){
        if(Input.GetButtonDown("Fire1") && isWeaponDrawn){
            //animator.SetTrigger(WeaponsConstants.SHOOT);
            //pistolAnimator.SetTrigger(WeaponsConstants.FIRE);
            currentWeapon.Shoot();
            if(collided){
                Vector3 position = hitPoint;
                GameObject bulletHoleInstance = Instantiate(bulletHole, position, crossHair.transform.rotation);
                bulletHoleInstance.transform.SetParent(bulletHoles.transform,true);
                bulletHoleInstance.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            }
            animator.SetTrigger(WeaponsConstants.FIRE);
            if(normalInfectantInRange){
                normalInfectantInRange.GetComponent<NormalInfectant>().GetShot(1000);

            }
        }
    }
    
    void SetCrossHairGreen(){
        SpriteRenderer sprite = crossHair.GetComponent<SpriteRenderer>();
        sprite.color = new Color (0, 255, 0, 1); 
    }

    void SetCrossHairRed() {
         SpriteRenderer sprite = crossHair.GetComponent<SpriteRenderer>();
         sprite.color = new Color (255, 0, 0, 1); 
    }


    // Update is called once per frame
    void Update()
    {   

        HandlePutDownWeapon();
        HandleFire();
        
    }


    public void SetWeapon(Weapon weapon) {
        animator.SetTrigger(PlayerConstants.SWITCH);
        if(currentWeapon && isWeaponDrawn){
            currentWeapon.Hide();
        }
        // GameObject test =  crossHairs[weapon.GetType()];
        if(currentWeapon) crossHairs[currentWeapon.GetType()].SetActive(false);
        rayCenter = weapon.GetAim();
        var(position,rotation) = weapon.GetCameraData();
        weaponCamera.transform.localPosition = position;
        weaponCamera.transform.localRotation = Quaternion.Euler(rotation);
        this.currentWeapon = weapon;
        currentWeapon.UnHide();
        if(isWeaponDrawn){
             HandleDrawWeapon();
             crossHairs[weapon.GetType()].SetActive(true);
             crossHair = crossHairs[weapon.GetType()];
        }
    
    }

    public bool GetIsweaponDrawn() {
        return isWeaponDrawn;
    }
  
}
