using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Callbacks;

public class BehaviorTreeEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    BehaviorTreeView treeView;
    InspectorView inspectorView;
    IMGUIContainer blackboardView;

    SerializedObject treeObject;
    SerializedProperty blackboardProperty;

    [MenuItem("Window/UI Toolkit/BehaviorTreeEditor")]
    public static void OpenWindow()
    {
        BehaviorTreeEditor wnd = GetWindow<BehaviorTreeEditor>();
        wnd.titleContent = new GUIContent("BehaviorTreeEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId, int line)
    {
        if (Selection.activeObject is BehaviorTree)
        {
            OpenWindow();
            return true;
        }
        return false;
    }

    public void OnEnable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStatechanged;
        EditorApplication.playModeStateChanged += OnPlayModeStatechanged;
    }

    public void OnDisable()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStatechanged;
    }

    private void OnPlayModeStatechanged(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredEditMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingEditMode:
                break;
            case PlayModeStateChange.EnteredPlayMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingPlayMode:
                break;
        }
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BehaviorTreeEditor.uxml");
        visualTree.CloneTree(root);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BehaviorTreeEditor.uss");
        root.styleSheets.Add(styleSheet);

        treeView = root.Q<BehaviorTreeView>();
        inspectorView = root.Q<InspectorView>();
        blackboardView = root.Q<IMGUIContainer>();
        blackboardView.onGUIHandler = () =>
        {
            if (treeObject != null)
            {
                treeObject.Update();
                EditorGUILayout.PropertyField(blackboardProperty);
                treeObject.ApplyModifiedPropertiesWithoutUndo();
            }
        };

        treeView.onNodeSelected = OnNodeSelectionChanged;

        OnSelectionChange();
    }

    private void OnSelectionChange()
    {
        BehaviorTree tree = Selection.activeObject as BehaviorTree;
        if (!tree && Selection.activeGameObject)
        {
            Runner runner = Selection.activeGameObject.GetComponent<Runner>();
            if (runner)
                tree = runner.tree;
        }

        if (Application.isPlaying)
        {
            if (tree && treeView != null)
                treeView.PopulateView(tree);
        }
        else
        {
            if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()) && treeView != null)
                treeView.PopulateView(tree);
        }

        if (tree != null)
        {
            treeObject = new SerializedObject(tree);
            blackboardProperty = treeObject.FindProperty("blackboard");
        }
    }

    void OnNodeSelectionChanged(NodeView nodeView)
    {
        inspectorView.UpdateSelection(nodeView);
    }

    private void OnInspectorUpdate()
    {
        treeView?.UpdateNodeStates();
    }
}