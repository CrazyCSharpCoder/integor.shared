namespace IntegorResponseDecoration
{
    public class ResponseBodyDecorationResult
    {
        public bool Success { get; }
        public object? NewValue { get; }

        public ResponseBodyDecorationResult(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// Successful result with a new body for response
        /// </summary>
        public ResponseBodyDecorationResult(object? newValue)
        {
            Success = true;
            NewValue = newValue;
        }
    }
}
