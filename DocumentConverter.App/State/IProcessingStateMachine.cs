using DocumentConverter.App.Models;

namespace DocumentConverter.App.State;

public interface IProcessingStateMachine
{
    public bool CanTransitionTo(ProcessingState fromState, ProcessingState toState);
}