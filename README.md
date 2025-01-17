## FoldoutGroup

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

## BoxGroup

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


## TabView & TabGroup

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

## Toggles & ToggleGroup

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

## DrawLine

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

## PositionHandle
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

## DrawRadius
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


