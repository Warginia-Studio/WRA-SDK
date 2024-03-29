using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    string Name { get; }
    
    string Description { get; }
    
    void Execute(params string[] args);
}
