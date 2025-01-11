namespace PowerTools.Attributes
{
    public interface ISceneAttribute
    {
        /// <summary>
        /// Should this attribute render in Scene View even when it's component
        /// is collapsed? <br/> Useful to reduce clutter when there is a lot of stuff in Scene View. 
        /// </summary>
        public bool HideWhenInspectorIsClosed { get; set; }

        /// <summary>
        /// Use this method for initialization.
        /// </summary>
        /// <param name="target">The Object Being Inspected.</param>
        /// <param name="property">
        ///     Serialized Information about the Field on which this 
        ///     attribute is applied.
        /// </param>
        /// <param name="field">Underlying Field of Serialized Property</param>
        public void Setup(UnityEngine.Object target, UnityEditor.SerializedProperty property, 
                          System.Reflection.FieldInfo field);

        /// <summary>
        /// Implement this to tell Power Editor what to draw in Scene View.
        /// </summary>
        void Draw();
    }
}