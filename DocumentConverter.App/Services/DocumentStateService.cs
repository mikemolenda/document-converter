using DocumentConverter.App.State;
using DocumentConverter.App.Models;
namespace DocumentConverter.App.Services;

public class DocumentStateService: IProcessingStateService
{
    private readonly IProcessingStateMachine _documentStateMachine;

    public DocumentStateService(DocumentStateMachine documentStateMachine)
    {
        _documentStateMachine = documentStateMachine;
    }

    public Task<ProcessingStateTransition> TransitionToAsync(Guid targetId, ProcessingState newState)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessingState> GetCurrentStateAsync(Guid targetId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProcessingStateTransition>> GetHistoryAsync(Guid targetId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanTransitionToAsync(Guid targetId, ProcessingState newState)
    {
        throw new NotImplementedException();
    }
}