using DocumentConverter.App.Models;

namespace DocumentConverter.App.State;

public class DocumentStateMachine : IProcessingStateMachine
{
    private static readonly Dictionary<ProcessingState, HashSet<ProcessingState>> _allowedTransitions = new()
    {
        { ProcessingState.New, new HashSet<ProcessingState> { ProcessingState.Processing, ProcessingState.UnexpectedError } },
        { ProcessingState.Processing, new HashSet<ProcessingState> { ProcessingState.Success, ProcessingState.Failure, ProcessingState.UnexpectedError } },
        { ProcessingState.Failure, new HashSet<ProcessingState> { ProcessingState.New } },
        { ProcessingState.UnexpectedError, new HashSet<ProcessingState> { ProcessingState.New } },
    };
    
    // Tests whether the transition is valid: 
    // The fromState must allow a transition out, and the toState must be allowed from the fromState
    public bool CanTransitionTo(ProcessingState fromState, ProcessingState toState)
    {
        return _allowedTransitions.ContainsKey(fromState) && _allowedTransitions[fromState].Contains(toState);
    }
}