using UnityEngine;
public class WeaponsConstants
{ 
 // public  string[] WEAPON_TYPES = {"tacticalShotgun", "assaultRifle", "huntingRifle", "submachinGun", "pistol"};
  
  public const string FIRE = "Fire";

  public const string SHOOT = "shoot";

  public const string DRAW_PISTOL = "drawPistol";

  // PISTOL DATA
  public static (string TYPE,  
                int RANGE, 
                int DAMAGE, 
                int RATE_OF_FIRE, 
                int CLIP_CAPACITY, 
                int MAX_AMMO, 
                string PATH) PISTOL_DATA = ( "pistol",
                                             20, 
                                             36, 
                                             300, 
                                             15, 
                                             -1, 
                                             "Prefabs/Weapons/Pistol/Modern Guns - Handgun/_Prefabs/Handgun Black/PistolShooting"
                                             );

public static  (Vector3 position, 
                Vector3 scale, 
                Vector3 rotation) PISTOL_TRANSFORMATIONS = (new Vector3(0.08407628f,-0.02758249f,-0.03026863f),
                                                            new Vector3(1.7f,1f,1f),
                                                            new Vector3(13.166f,96.78f,91.854f)
                                                          
                                                        );
  

public static (Vector3 position, 
               Vector3 rotation 
               ) PISTOsL_CAMERA_DATA = (
                                        new Vector3(0.05913162f,1.538786f,0.2859898f),
                                        new Vector3(18.599f,-5.792f,-0.117f)
               );

public static (Vector3 position, 
               Vector3 rotation 
               ) PISTOL_CAMERA_DATA = (
             // new Vector3(0.1358f,1.6335f,-0.0219f),
                                        // new Vector3(5.88f,-5.67f,0.006f)
                                        // new Vector3(0.05913162f,1.538786f,0.2859898f),
                                        // new Vector3(18.599f,-5.792f,-0.117f)
                                        
                                        // new Vector3(-0.007f,1.555f,0.0048f),
                                        new Vector3(-0.0209999997f,1.58000004f,0.0780000016f),
                                        new Vector3(5.88f,-5.67f,0.006f)
               );






  // SHOT GUN DATA
  public static (string TYPE,  
                int RANGE, 
                int DAMAGE, 
                int RATE_OF_FIRE, 
                int CLIP_CAPACITY, 
                int MAX_AMMO, 
                string PATH) SHOT_GUN_DATA = ( "shotgun",
                                             20, 
                                             350, 
                                             200, 
                                             10, 
                                             130, 
                                             "Prefabs/Weapons/shotgun/MARMO3"
                                             );
  
 public static  (Vector3 position, 
                    Vector3 scale, 
                    Vector3 rotation) SHOT_GUN_TRANSFORMATIONS = (
                                                            // new Vector3(0.25f,-0.026f,0.015f),
                                                            // new Vector3(0.1f,0.1f,0.1f),
                                                            // new Vector3(-90f,180f,0f)
                                                            
                                                            new Vector3(0.150999993f,-0.0289999992f,0.0250000004f),
                                                             new Vector3(0.1f,0.1f,0.1f),
                                                            new Vector3(270.756409f,261.248047f,286.122375f)
                                                           

                                                        );

  
  // SMG DATA
  public static (string TYPE,  
                int RANGE, 
                int DAMAGE, 
                int RATE_OF_FIRE, 
                int CLIP_CAPACITY, 
                int MAX_AMMO, 
                string PATH) SMG_DATA = ( "smg",
                                             20, 
                                             20, 
                                             900, 
                                             50, 
                                             70, 
                                             "Prefabs/Weapons/Pistol/Modern Guns - Handgun/_Prefabs/Handgun Black/PistolShooting"
                                             );

  

  

  // HUNTING RIFLE DATA
  public static (string TYPE,  
                int RANGE, 
                int DAMAGE, 
                int RATE_OF_FIRE, 
                int CLIP_CAPACITY, 
                int MAX_AMMO, 
                string PATH) HUNTING_RIFLE_DATA = ( "huntingRifle",
                                             20, 
                                             90, 
                                             240, 
                                             15, 
                                             165, 
                                            "Prefabs/Weapons/HuntingRifle/Prefab/Scar"
                                             );
 
   public static  (Vector3 position, 
                    Vector3 scale, 
                    Vector3 rotation) HUNTING_RIFLE_TRANSFORMATIONS = (new Vector3(0.2712f,-0.0371f,0.0665f),
                                                            new Vector3(0.8f,0.8f,0.8f),
                                                            new Vector3(-90f,0f,-180f)
                                                          
                                                        );
 
 
 
 
 
 
 
 
 
 
 
 
 
  // ASSAULT RIFLE DATA
  public static (string TYPE,  
                int RANGE, 
                int DAMAGE, 
                int RATE_OF_FIRE, 
                int CLIP_CAPACITY, 
                int MAX_AMMO, 
                string PATH) ASSAULT_RIFLE_DATA = ("assaultRifle",
                                             20, 
                                             33, 
                                             600, 
                                             50, 
                                             450, 
                                             "Prefabs/Weapons/Rifle/Prefabs/RifleShooting"
                                             );
                                         

    public static  (Vector3 position, 
                    Vector3 scale, 
                    Vector3 rotation) RIFLE_TRANSFORMATIONS = (
                                                            // new Vector3(0.25f,-0.026f,0.015f),
                                                            // new Vector3(0.7f,0.5f,0.5f),
                                                            // new Vector3(0.517f,-79.043f,-90.019f)

                                                            //  new Vector3(0.248999998f,-0.0149999997f,0.00800000038f),
                                                            //  new Vector3(0.699999988f,0.699999988f,0.600000024f),
                                                            //  new Vector3(2.02892876f,287.376648f,263.721405f)

                                                            new Vector3(0.229000002f,-0.0240000002f,0.0189999994f),
                                                            new Vector3(0.550000012f,0.649999976f,0.5f),
                                                            new Vector3(1.40168953f,285.174805f,261.383911f)

                                                        );


    
public static (Vector3 position, 
               Vector3 rotation 
               ) RIFLE_CAMERA_DATA = (
             // new Vector3(0.1358f,1.6335f,-0.0219f),
                                        // new Vector3(5.88f,-5.67f,0.006f)
                                        // new Vector3(0.05913162f,1.538786f,0.2859898f),
                                        // new Vector3(18.599f,-5.792f,-0.117f)
                                        
                                        // new Vector3(-0.007f,1.555f,0.0048f),
                                        new Vector3(-0.0209999997f,1.58000004f,0.0780000016f),
                                        new Vector3(5.88f,-5.67f,0.006f)
               );




}