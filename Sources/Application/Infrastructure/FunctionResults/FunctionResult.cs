using JetBrains.Annotations;

namespace Mmu.WpfGraphApiTool.Infrastructure.FunctionResults
{
    public class FunctionResult<T> : FunctionResult
    {
        public T Value { get; }

        public FunctionResult(bool isSuccess, T value)
            : base(isSuccess)
        {
            Value = value;
        }
    }

    [PublicAPI]
    public class FunctionResult
    {
        public bool IsSuccess { get; }

        public FunctionResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public static FunctionResult CreateFailure()
        {
            return new FunctionResult(false);
        }

        public static FunctionResult<T> CreateFailure<T>()
        {
            return new FunctionResult<T>(false, default);
        }

        public static FunctionResult<T> CreateFromDefault<T>(T value)
        {
            // Careful, default doesn't work, it has to be default(T)
            return Equals(value, default(T)) ? CreateFailure<T>() : CreateSuccess(value);
        }

        public static FunctionResult CreateSuccess()
        {
            return new FunctionResult(true);
        }

        public static FunctionResult<T> CreateSuccess<T>(T value)
        {
            return new FunctionResult<T>(true, value);
        }
    }
}