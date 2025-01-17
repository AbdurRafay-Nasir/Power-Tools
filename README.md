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
![image](https://github.com/user-attachments/assets/adfab1c8-1b97-41b2-8261-653bf443a6d2)
![image](https://github.com/user-attachments/assets/ad6498ce-4264-4cc2-b093-b5f8d55e95ed)

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

    [FoldoutGroup("Floats", MarginTop = 10f)]
    public float float1 = 2.5f;

    [FoldoutGroup("Doubles")]
    public double double1 = 5.2f;
    public double double2 = 6.8f;
    // EndGroup not required as no Fields remain
}
```
![image](https://github.com/user-attachments/assets/f964662b-2f2b-405a-a250-f9459681c6de)

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
![image](https://github.com/user-attachments/assets/85dbb780-1737-4f5e-9bfb-9c10ce97d275)

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
![image](https://github.com/user-attachments/assets/73e99e7d-92fe-4291-8813-e425ab3c387e)


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


