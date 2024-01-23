using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor;

public class NodeView : Node
{
    public Action<NodeView> onNodeSelected;

    public UserNode node;
    public Port input;
    public Port output;

    public NodeView(UserNode node) : base("Assets/Editor/NodeView.uxml")
    {
        this.node = node;
        this.title = node.nodeName;
        this.viewDataKey = node.guid;

        style.left = node.position.x;
        style.top = node.position.y;

        CreateInputPorts();
        CreateOutputPorts();
        SetupClasses();
    }

    void SetupClasses()
    {
        if (node is ActionNode)
        {
            AddToClassList("action");
        }
        else if (node is CompositeNode)
        {
            AddToClassList("composite");
        }
        else if (node is DecoratorNode)
        {
            AddToClassList("decorator");
        }
        else if (node is RootNode)
        {
            AddToClassList("root");
        }
    }

    void CreateInputPorts()
    {
        if (node is ActionNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is CompositeNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is DecoratorNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {

        }

        if (input != null)
        {
            input.portName = "";
            input.style.flexDirection = FlexDirection.Column;
            inputContainer.Add(input);
        }
    }

    void CreateOutputPorts()
    {
        if (node is ActionNode)
        {

        }
        else if (node is CompositeNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Multi, typeof(bool));
        }
        else if (node is DecoratorNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
        }
        else if (node is RootNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));
        }

        if (output != null)
        {
            output.portName = "";
            output.style.flexDirection = FlexDirection.ColumnReverse;
            outputContainer.Add(output);
        }
    }

    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        //Undo.RecordObject(node, "Behavior Tree (Set Position)");
        node.position.x = newPos.xMin;
        node.position.y = newPos.yMin;
        EditorUtility.SetDirty(node);
    }

    public override void OnSelected()
    {
        base.OnSelected();

        if (onNodeSelected != null)
        {
            onNodeSelected.Invoke(this);
        }
    }

    public void SortChildren()
    {
        CompositeNode composite = node as CompositeNode;
        if (composite && composite.children != null)
            composite.children.Sort(SortByHorizontalPosition);
    }

    private int SortByHorizontalPosition(UserNode left, UserNode right)
    {
        return left.position.x < right.position.x ? -1 : 1;
    }

    public void UpdateState()
    {
        RemoveFromClassList("running");
        RemoveFromClassList("failure");
        RemoveFromClassList("success");

        if (Application.isPlaying)
            switch (node.state)
            {
                case UserNode.State.Running:
                    if (node.started)
                        AddToClassList("running");
                    break;
                case UserNode.State.Failure:
                    AddToClassList("failure");
                    break;
                case UserNode.State.Success:
                    AddToClassList("success");
                    break;
            }
    }
}