using System.Text.RegularExpressions;

namespace CodeSmells.Exemplos.exemplo1.extension
{
    public static class CPFExtension
    {
        public static bool IsValid(this CPF cpf)
        {
            // Remover caracteres não numéricos
            cpf.Value = Regex.Replace(cpf.Value, @"[^\d]", "");

            // Verificar se o CPF possui 11 dígitos
            if (cpf.Value.Length != 11)
                return false;

            // Verificar se o Value possui todos os dígitos iguais (ex: 111.111.111-11)
            bool allDigitsAreEqual = true;
            for (int i = 1; i < cpf.Value.Length; i++)
            {
                if (cpf.Value[i] != cpf.Value[0])
                {
                    allDigitsAreEqual = false;
                    break;
                }
            }
            if (allDigitsAreEqual)
                return false;

            // Calcular primeiro dígito verificador
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (cpf.Value[i] - '0') * (10 - i);

            int firstDigit = 11 - (sum % 11);
            if (firstDigit >= 10)
                firstDigit = 0;

            // Calcular segundo dígito verificador
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (cpf.Value[i] - '0') * (11 - i);

            int secondDigit = 11 - (sum % 11);
            if (secondDigit >= 10)
                secondDigit = 0;

            // Verificar se os dígitos verificadores são válidos
            return (cpf.Value[9] - '0') == firstDigit && (cpf.Value[10] - '0') == secondDigit;
        }
    }
}
