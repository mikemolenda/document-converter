using DocumentConverter.App.Models;

namespace DocumentConverter.App.Services;

public interface IProcessingStateService
{
    Task<ProcessingStateTransition> TransitionToAsync(Guid targetId, ProcessingState newState);
    Task<ProcessingState> GetCurrentStateAsync(Guid targetId);
    Task<IEnumerable<ProcessingStateTransition>> GetHistoryAsync(Guid documentId);
    Task<bool> CanTransitionToAsync(Guid targetId, ProcessingState newState);
}