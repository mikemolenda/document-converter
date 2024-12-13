using DocumentConverter.App.Models;

namespace DocumentConverter.App.State;

public class DocumentFileStateMachine : IProcessingStateMachine
{
    private static readonly Dictionary<ProcessingState, HashSet<ProcessingState>> _allowedTransitions = new()
    {
        { ProcessingState.New, new HashSet<ProcessingState> { ProcessingState.Uploaded, ProcessingState.UnexpectedError } },
        { ProcessingState.Uploaded, new HashSet<ProcessingState> { ProcessingState.Converting, ProcessingState.Saving, ProcessingState.UnexpectedError } },
        { ProcessingState.Converting, new HashSet<ProcessingState> { ProcessingState.Converted, ProcessingState.ConversionFailed, ProcessingState.UnexpectedError } },
        { ProcessingState.Converted, new HashSet<ProcessingState> { ProcessingState.Saving, ProcessingState.UnexpectedError } },
        { ProcessingState.Saving, new HashSet<ProcessingState> { ProcessingState.Saved, ProcessingState.SavingFailed, ProcessingState.UnexpectedError } },
        { ProcessingState.Saved, new HashSet<ProcessingState> { ProcessingState.Success, ProcessingState.UnexpectedError } },
        { ProcessingState.ConversionFailed, new HashSet<ProcessingState> { ProcessingState.New } },
        { ProcessingState.SavingFailed, new HashSet<ProcessingState> { ProcessingState.New } },
        { ProcessingState.UnexpectedError, new HashSet<ProcessingState> { ProcessingState.New } },
    };
    
    // Tests whether the transition is valid: 
    // The fromState must allow a transition out, and the toState must be allowed from the fromState
    public bool CanTransitionTo(ProcessingState fromState, ProcessingState toState)
    {
        return _allowedTransitions.ContainsKey(fromState) && _allowedTransitions[fromState].Contains(toState);
    }
}