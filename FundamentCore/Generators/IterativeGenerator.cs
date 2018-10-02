namespace FundamentCore.Generators
{
    public class IterativeGenerator<T> : Interface.IGenerate<T>
    {
        T _state;
        Interface.IPartialFunction<T, T> _transition;

        public IterativeGenerator(T initialState, Interface.IPartialFunction<T, T> transition)
        {
            _state = initialState;
            _transition = transition;
        }

        public T Generate()
        {
            var s = _state;
            _state = _transition.Apply(s);
            return s;
        }
    }
}
