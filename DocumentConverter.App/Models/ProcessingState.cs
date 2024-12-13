namespace DocumentConverter.App.Models;

public enum ProcessingState
{
    New,
    Uploaded,
    Processing,
    Converting,
    Converted,
    Saving,
    Saved,
    Success,
    Failure,
    ConversionFailed,
    SavingFailed,
    UnexpectedError
}