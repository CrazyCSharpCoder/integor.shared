namespace IntegorResponseDecoration
{
    public class ResponseObjectDecorationResult
    {
        public bool Success { get; }
        public object? Value { get; }

        public ResponseObjectDecorationResult(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// Successful result with a new body for response
        /// </summary>
        public ResponseObjectDecorationResult(object? value)
        {
            Success = true;
            Value = value;
        }
    }
}
