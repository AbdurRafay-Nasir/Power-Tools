# Power Tools
A utility tool to help create custom inspectors with ease. Use Attirbutes to create the look of inspector that you want.

## Attributes
There are three kind of attributes.
- **Property** Only works on individual fields. 
- **Group** Works on multiple fields.
- **Scene** Works on individual fields. Has effects in SceneView. No custom inspector is made 

## Property Attributes

### Title
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [Title("This is Spartaaaaaa!!!!", "Assemble Brodars. We are gonna win this game")]
    public int i1;
    public int i2;
}
```
![image](https://github.com/user-attachments/assets/66675955-d566-48e0-8b84-8feee09bd004)

### Button
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [Button("Add Coins")]
    private void AddCoins()
    {
        Debug.Log("Coins Added...");
    }
}
```
![image](https://github.com/user-attachments/assets/a957d602-9144-435b-ac33-1c4bbe9293b3)

### GetFromChild
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // Searches in DIRECT childs and fills the component
    // if found, otherwise shows an error in a box
    [GetFromChild] 
    public MeshRenderer childRenderer;

    // Searhes in all childs (children, grand children and so on)
    [GetFromChild(true)]
    public BoxCollider childCollider;
}
```

### GetFromSelf
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // Finds and fills reference if found on same game object
    [GetFromSelf]
    public MeshRenderer childRenderer;
}
```

### GetFromParent
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // Finds and fills reference if found on direct parent
    [GetFromParent]
    public MeshRenderer childRenderer;

    // Finds and fills reference if found on any parent
    // (direct, grand and so on)
    [GetFromParent(true)]
    public BoxCollider childCollider;
}
```

### Margin
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [Margin(Vertical = 20f)]
    public float f1;
}
```
![image](https://github.com/user-attachments/assets/d90d7101-ffc9-4a07-97d1-9955707886ce)

### Path
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // Creates an object field. Drag and Drop any file/folder.
    // Stores the path in filePath Field
    [Path]
    public string filePath;
}
```
![image](https://github.com/user-attachments/assets/d5badd41-abf8-4a49-8976-1e1b3de142e9)

### ReadOnly
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // Disallows modifications. Field is still serialized
    [ReadOnly]
    public float currentHealth;
}
```
![image](https://github.com/user-attachments/assets/0244caed-552b-4e2a-8b7a-7c6ab9934dc8)

### Required
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [Required]
    public GameObject bulletPrefab;

    [Required("Bruh. Plz fill this")]
    public GameObject impactPrefab;
}
```
![image](https://github.com/user-attachments/assets/0093e495-8816-4146-aefc-a98c44642996)

### SceneName
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // Displays a dropdown of all Scenes that are
    // in in Build Settings / Profiles
    [SceneName]
    public string nextScene;
}
```
![image](https://github.com/user-attachments/assets/d75019a9-e0fd-4947-9124-1c5ddd391b22)



## Group Attributes
Thse attributes affect multiple fields, these can also be nested.

### FoldoutGroup

```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [FoldoutGroup("Ints")]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;
}
```
![image](https://github.com/user-attachments/assets/14caeb52-063e-4aaa-8427-c9bc168df105)


```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [FoldoutGroup("Ints")]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;     
    [EndGroup]

    [FoldoutGroup("Floats", MarginTop = 2f)]
    public float float1 = 2.5f;

    [FoldoutGroup("Doubles")]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
    // EndGroup not required as no Fields remain
}
```
![image](https://github.com/user-attachments/assets/8670d0b1-41f6-448c-bc8b-8aee75c52388)

### BoxGroup

```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [BoxGroup(MarginVertical = 7f)]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;     
    [EndGroup]

    [BoxGroup(BorderColorHex = "#4EC9B0")]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
}
```
![image](https://github.com/user-attachments/assets/4ce04441-2745-4bb0-bf72-049abe2fb784)


```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [BoxGroup(MarginVertical = 7f)]
    public int int1 = 10;

    [FoldoutGroup("Ints")]
    public int int2 = 10;
    public int int3 = 10;  
    
    [EndGroup(2)] // specify how many groups should be closed

    [BoxGroup(BorderColorHex = "#4EC9B0")]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
}
```
![image](https://github.com/user-attachments/assets/86a7005c-ba50-4bc4-ae9a-0c2cf5a2b3f8)


### TabView & TabGroup

```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // TabView is a group attribute, required to create Tabs
    [TabView]
    [TabGroup("Int Fields")]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;
    
    [EndGroup]

    [TabGroup("Double Fields")]
    [GUI(MarginTop = 5f)]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
}
```
![image](https://github.com/user-attachments/assets/206f5c19-6224-4b99-ba1e-2c4c250f3d5e)

### Toggles & ToggleGroup

```csharp
using UnityEngine;
using PowerTools.Attributes;

[Toggles("Ints, Doubles, Strings")]
public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [ToggleGroup("Ints")]
    public int int1 = 10;
    public int int2 = 10;
    public int int3 = 10;
    [EndGroup]

    [ToggleGroup("Doubles")]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
    [EndGroup]

    [ToggleGroup("Strings")]
    public double string1 = 5.2f;
    public double string2 = 6.8f;
}
```
![image](https://github.com/user-attachments/assets/45a4d569-2f75-42ac-abfd-8920223937a8)
\
![image](https://github.com/user-attachments/assets/cfa354ff-9e97-41c7-be25-a787c6f08340)

### ReadOnlyGroup
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [BoxGroup(MarginVertical = 7f)]
    public int int1 = 10;
    public int int2 = 10;
    [EndGroup]

    [BoxGroup(BorderColorHex = "#4EC9B0")]
    [ReadOnlyGroup] // Unmodifiable Fields
    public double double1 = 5.2f;
    public double double2 = 6.8f;
}
```
![image](https://github.com/user-attachments/assets/8a882b6f-0ea7-4042-ab89-81ece6e91763)

## Scene Attributes
These attributes have effects in scene view.
### DrawLine

```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [DrawLine]
    public Vector3 target;
}
```
![image](https://github.com/user-attachments/assets/0a186c3c-51f7-4fda-b018-fb2fb3703239)

### PositionHandle
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    // PositionHandle adds a move tool to manipulate
    // Vector3 in Scene.Also works on Vector2 and Transform
    [DrawLine, PositionHandle] 
    public Vector3 target;
}
```
![image](https://github.com/user-attachments/assets/47459e34-32d0-4164-b36c-ff6ce8aea9b7)

### DrawRadius
```csharp
using UnityEngine;
using PowerTools.Attributes;

public class PowerAttributesShowcase : PowerMonoBehaviour
{
    [DrawRadius("#FFFF00")] 
    public float target;
}
```
![image](https://github.com/user-attachments/assets/7afbd2c8-2ba2-4dc6-9ca8-d6a9c2c85b69)




