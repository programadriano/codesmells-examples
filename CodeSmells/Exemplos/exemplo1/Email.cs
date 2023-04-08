namespace CodeSmells.Exemplos.exemplo1
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            Value = value;
        }
    }
}
