using UnityEngine;
using UnityEngine.UIElements;
using PowerTools.Attributes;

[Toggles("General, Advanced, Debug")]
public class Tester : PowerMonoBehaviour
{
    // General Settings
    [ToggleGroup("General")]
    [BoxGroup]
    public string playerName;

    [BoxGroup]
    [Required]
    public int playerID;

    [ToggleGroup("General")]
    [FoldoutGroup("Gameplay Settings")]
    [Range(0, 100)]
    public float health;

    [FoldoutGroup("Gameplay Settings")]
    [Range(0, 100)]
    public float stamina;

    [EndGroup] // Ends FoldoutGroup "Gameplay Settings"
    [EndGroup] // Ends ToggleGroup "General"

    // Advanced Settings
    [ToggleGroup("Advanced")]
    [TabView(align = Alignment.Center)]
    [TabGroup("Graphics")]
    public bool enableShadows;

    [EndGroup, TabGroup("Graphics")]
    public bool enablePostProcessing;

    [EndGroup, TabGroup("Audio")]
    [Range(0, 1)]
    public float masterVolume;

    [EndGroup, TabGroup("Audio")]
    [Range(0, 1)]
    public float musicVolume;

    [EndGroup, TabGroup("Controls")]
    public KeyCode jumpKey;

    [EndGroup, TabGroup("Controls")]
    public KeyCode shootKey;

    [EndGroup(3)] // Ends TabView

    // Debug Settings
    [ToggleGroup("Debug")]
    [ReadOnly]
    public string debugInfo;

    [ToggleGroup("Debug")]
    [Helpbox("This is a debug variable for testing purposes.", MessageType.None)]
    public bool showDebugLogs;

    [EndGroup] // Ends ToggleGroup "Debug"

    // Scene References (Casued Problems)
    //[SceneName]
    //public string mainScene;

    //[SceneName]
    //public string gameOverScene;

    // File and Folder Paths
    [FilePath]
    public string configFilePath;

    [FolderPath]
    public string saveDataFolderPath;

    // Conditional Display
    [ShowIf("showAdvancedOptions")]
    public int advancedOptionValue;

    public bool showAdvancedOptions = true;

    // Gizmo Drawing
    [DrawLine(HideWhenInspectorIsClosed = true), PositionHandle(HideWhenInspectorIsClosed = true)]
    public Vector3 pointA;

    [DrawRadius(HideWhenInspectorIsClosed = true)]
    public float centerPoint;

    // Position Handles
    [PositionHandle(HideWhenInspectorIsClosed = true)]
    public Vector3 handlePosition;

    // Methods
    [Button("GG")]
    public void ResetPlayerStats()
    {
        health = 100f;
        stamina = 100f;
        Debug.Log("Player stats reset.");
    }

    [Button("BB")]
    public void LoadMainScene()
    {
        // Logic to load the main scene
        Debug.Log("Loading main scene...");
    }

    ///* // Inherited from Joint
    //public Rigidbody connectedBody;
    //public Vector3 anchor;
    //public Vector3 axis;
    //public bool autoConfigureConnectedAnchor;
    //public Vector3 connectedAnchor;
    //public Vector3 secondaryAxis;
    //public ConfigurableJointMotion xMotion;
    //public ConfigurableJointMotion yMotion;
    //public ConfigurableJointMotion zMotion;
    //public ConfigurableJointMotion angularXMotion;
    //public ConfigurableJointMotion angularYMotion;
    //public ConfigurableJointMotion angularZMotion;

    //// linear limit spring
    //public float spring;
    //public float damper;

    //// linear limit
    //public float limit;
    //public float bounciness;
    //public float contactDistance;


    //public float breakForce;
    //public float breakTorque;
    //public bool enableCollision;
    //public bool enablePreprocessing;
    //public float massScale;
    //public float connectedMassScale;

    //// ConfigurableJoint-specific properties

    //// Linear Motion

    //// Angular Motion

    //// Linear Limit
    //public SoftJointLimitSpring linearLimitSpring;
    //public SoftJointLimit linearLimit;

    //// Angular Limits
    //public SoftJointLimitSpring angularXLimitSpring;
    //public SoftJointLimit lowAngularXLimit;
    //public SoftJointLimit highAngularXLimit;
    //public SoftJointLimitSpring angularYZLimitSpring;
    //public SoftJointLimit angularYLimit;
    //public SoftJointLimit angularZLimit;

    //// Target Settings
    //public Vector3 targetPosition;
    //public Vector3 targetVelocity;
    //public Quaternion targetRotation;
    //public Vector3 targetAngularVelocity;

    //// Drive Settings
    //public JointDrive xDrive;
    //public JointDrive yDrive;
    //public JointDrive zDrive;
    //public RotationDriveMode rotationDriveMode;
    //public JointDrive angularXDrive;
    //public JointDrive angularYZDrive;
    //public JointDrive slerpDrive;

    //// Projection Settings
    //public JointProjectionMode projectionMode;
    //public float projectionDistance;
    //public float projectionAngle;

    //// Miscellaneous
    //public bool configuredInWorldSpace;
    //public bool swapBodies;

    //*/
}
