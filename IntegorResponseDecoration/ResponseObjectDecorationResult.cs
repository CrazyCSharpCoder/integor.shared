namespace IntegorResponseDecoration
{
    public class ResponseObjectDecorationResult
    {
        public bool Success { get; }
        public object? NewValue { get; }

        public ResponseObjectDecorationResult(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// Successful result with a new body for response
        /// </summary>
        public ResponseObjectDecorationResult(object? newValue)
        {
            Success = true;
            NewValue = newValue;
        }
    }
}
