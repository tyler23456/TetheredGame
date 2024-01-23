using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using System;
using System.Linq;

public class BehaviorTreeView : GraphView
{
    public Action<NodeView> onNodeSelected;

    public new class UxmlFactory : UxmlFactory<BehaviorTreeView, GraphView.UxmlTraits> { }
    BehaviorTree tree;

    public BehaviorTreeView()
    {
        Insert(0, new GridBackground());

        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BehaviorTreeEditor.uss");
        styleSheets.Add(styleSheet);

        //Undo.undoRedoPerformed += OnUndoRedo;
    }

    private void OnUndoRedo()
    {
        PopulateView(tree);
        AssetDatabase.SaveAssets();
    }

    internal void PopulateView(BehaviorTree tree)
    {
        this.tree = tree;

        graphViewChanged -= OnGraphViewChanged;
        DeleteElements(graphElements); //clear out anything from previous tree
        graphViewChanged += OnGraphViewChanged;

        if (tree.rootNode == null)
        {
            tree.rootNode = tree.createNode(typeof(RootNode)) as RootNode;
            EditorUtility.SetDirty(tree);
            AssetDatabase.SaveAssets();
        }

        //creates node views
        tree.nodes.ForEach(n => CreateNodeView(n));

        //create edges
        tree.nodes.ForEach(n =>
        {
            var children = tree.GetChildren(n);
            children.ForEach(c =>
            {
                NodeView parentView = FindNodeView(n);
                NodeView childView = FindNodeView(c);

                Edge edge = parentView.output.ConnectTo(childView.input);
                AddElement(edge);
            });
        });

        //EditorUtility.SetDirty(tree);
        //AssetDatabase.SaveAssets();
    }

    void CreateNodeView(UserNode node)
    {
        NodeView nodeView = new NodeView(node);
        nodeView.onNodeSelected = onNodeSelected; //added later
        AddElement(nodeView);
    }

    NodeView FindNodeView(UserNode node)
    {
        return GetNodeByGuid(node.guid) as NodeView;
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        return ports.ToList().Where(endport => endport.direction != startPort.direction && endport.node != startPort.node).ToList();
    }


    private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
    {
        if (graphViewChange.elementsToRemove != null)
        {
            graphViewChange.elementsToRemove.ForEach(elem =>
            {
                NodeView nodeView = elem as NodeView;
                if (nodeView != null)
                {
                    tree.DeleteNode(nodeView.node);
                }

                Edge edge = elem as Edge;
                if (edge != null)
                {
                    NodeView parentView = edge.output.node as NodeView;
                    NodeView childView = edge.input.node as NodeView;
                    tree.RemoveChild(parentView.node, childView.node);
                }
            });
        }

        if (graphViewChange.edgesToCreate != null)
        {
            graphViewChange.edgesToCreate.ForEach(edge =>
            {
                NodeView parentView = edge.output.node as NodeView;
                NodeView childView = edge.input.node as NodeView;
                tree.AddChild(parentView.node, childView.node);
            });
        }

        if (graphViewChange.movedElements != null)
        {
            nodes.ForEach(n =>
            {
                NodeView view = n as NodeView;
                view.SortChildren();
            });
        }


        return graphViewChange;
    }

    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {


        var types = TypeCache.GetTypesDerivedFrom<ActionNode>();
        foreach (var type in types)
        {
            evt.menu.AppendAction($"[{type.BaseType.Name.Replace("Node", "")}] {type.Name.Replace("Node", "")}", (a) => CreateNode(type));
        }

        var types2 = TypeCache.GetTypesDerivedFrom<CompositeNode>();
        foreach (var type in types2)
        {
            evt.menu.AppendAction($"[{type.BaseType.Name.Replace("Node", "")}] {type.Name.Replace("Node", "")}", (a) => CreateNode(type));
        }

        var types3 = TypeCache.GetTypesDerivedFrom<DecoratorNode>();
        foreach (var type in types3)
        {
            evt.menu.AppendAction($"[{type.BaseType.Name.Replace("Node", "")}] {type.Name.Replace("Node", "")}", (a) => CreateNode(type));
        }

        evt.menu.AppendAction("Delete", actionEvent => DeleteSelection());
    }


    void CreateNode(System.Type type)
    {
        UserNode node = tree.createNode(type);
        CreateNodeView(node);
    }

    public void UpdateNodeStates()
    {
        nodes.ForEach(n =>
        {
            NodeView view = n as NodeView;
            view.UpdateState();
        });
    }
}