namespace DocumentConverter.App.Models;

public enum ProcessingState
{
    New,
    Uploaded,
    Converting,
    Converted,
    Saving,
    Saved,
    Success,
    ConversionFailed,
    SavingFailed,
    UnexpectedError
}