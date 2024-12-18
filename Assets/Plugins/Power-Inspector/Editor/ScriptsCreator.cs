#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEngine;

namespace PowerEditor
{ 
    public class ScriptsCreator
    {
        private const string PROPERTY_ATTRIBUTE_TEMPLATE_PATH = "Assets/Plugins/Power-Inspector/Editor/Templates/PropertyAttribute.cs.txt";
        private const string GROUP_ATTRIBUTE_TEMPLATE_PATH = "Assets/Plugins/Power-Inspector/Editor/Templates/GroupAttribute.cs.txt";
        private const string DRAWER_TEMPLATE_PATH = "Assets/Plugins/Power-Inspector/Editor/Templates/PropertyAttributeDrawer.cs.txt";

        #region Create Attribute

        [MenuItem("Assets/Create/Power Editor/Property Attribute", priority = 5)]
        public static void CreatePropertyAttribute()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(PROPERTY_ATTRIBUTE_TEMPLATE_PATH, 
                                                                "NewPropertyAttribute.cs");
        }

        [MenuItem("Assets/Create/Power Editor/Group Attribute", priority = 5)]
        public static void CreateGroupAttribute()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(GROUP_ATTRIBUTE_TEMPLATE_PATH,
                                                                "NewGroupAttribute.cs");
        }

        #endregion

        #region Create Attribute Drawer

        [MenuItem("Assets/Create/Power Editor/Attribute Drawer", priority = 5)]
        public static void CreateEditorScriptForSelected()
        {
            string selectedFileName = Selection.activeObject.name;

            string templateFileContent = File.ReadAllText(DRAWER_TEMPLATE_PATH);
            string editorScriptContent = templateFileContent.Replace("#ATTRIBUTENAME#", selectedFileName);

            string relativeEditorScriptPath = "Assets/Plugins/Power-Inspector/Editor/Drawers/" + selectedFileName + "Drawer.cs";

            File.WriteAllText(relativeEditorScriptPath, editorScriptContent);

            AssetDatabase.Refresh();

            Object editorScript = AssetDatabase.LoadAssetAtPath<Object>(relativeEditorScriptPath);
            Selection.activeObject = editorScript;
        }

        [MenuItem("Assets/Create/Power Editor/Attribute Drawer", true)]
        public static bool ValidateCreateEditorScriptForSelected()
        {
            // GetAssetPath returns the relative path of the selected item
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);

            // Check whether selected object is a file or folder
            // If it's not a file, stop execution
            if (AssetDatabase.IsValidFolder(path))
                return false;

            // Check if the selected file is a C# file
            if (Path.GetExtension(path) != ".cs")
                return false;

            // Stop exectuion if Template file does not exist
            if (!File.Exists(DRAWER_TEMPLATE_PATH))
                return false;

            string relativeEditorScriptPath = "Assets/Plugins/Power-Inspector/Editor/Drawers/" + Selection.activeObject.name + "Drawer.cs";

            return !File.Exists(relativeEditorScriptPath);
        }


        #endregion

    }
}

#endif
