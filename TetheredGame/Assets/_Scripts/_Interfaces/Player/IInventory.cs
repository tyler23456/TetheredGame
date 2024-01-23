using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    int index { get; }
    int count { get; }
    string itemName { get; }
    int itemCount { get; }
    int Count(string name);
    void Add(string item, int count);
    void AddRange(List<(string name, int count)> items);
    void Remove(string item, int count = 1);
    void Scroll(int offset);
    string Name(int index);
    int Count(int index);


    public string[] GetNames();
    public int[] GetCounts();
    void SetNamesAndCounts(string[] itemNames, int[] ItemCounts);
}
