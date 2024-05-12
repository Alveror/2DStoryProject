using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogVariables
{
    private Dictionary<string, Ink.Runtime.Object> _variables;

    public DialogVariables(TextAsset loadGlobalsJSON)
    {

        Story globalVariablesStory = new Story(loadGlobalsJSON.text);

        _variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            _variables.Add(name,value);
            Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }
    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (_variables.ContainsKey(name))
        {
            _variables.Remove(name);
            _variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string,Ink.Runtime.Object> variable in _variables)
        {
            story.variablesState.SetGlobal(variable.Key,variable.Value);
        }
    }
}
