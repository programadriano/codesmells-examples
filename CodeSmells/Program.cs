// See https://aka.ms/new-console-template for more information

using CodeSmells.Exemplos.exemplo1;
using CodeSmells.Exemplos.exemplo1.extension;
using System.Net.Mail;
using System.Text.RegularExpressions;

#region [exemplo-1]

var pessoa = new Pessoa
{
    CPF = "123.456.789-00",
    Email = "tadriano@fiap.com"
};



bool isCPFValid = IsValidCPF(pessoa.CPF);
bool isEmailValid = IsValidEmail(pessoa.Email);

Console.WriteLine("CPF é válido? " + (isCPFValid ? "Sim" : "Não"));
Console.WriteLine("Email é válido? " + (isEmailValid ? "Sim" : "Não"));

bool IsValidCPF(string cpf)
{
    // Remover caracteres não numéricos
    cpf = Regex.Replace(cpf, @"[^\d]", "");

    // Verificar se o CPF possui 11 dígitos
    if (cpf.Length != 11)
        return false;

    // Verificar se o CPF possui todos os dígitos iguais (ex: 111.111.111-11)
    bool allDigitsAreEqual = true;
    for (int i = 1; i < cpf.Length; i++)
    {
        if (cpf[i] != cpf[0])
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
        sum += (cpf[i] - '0') * (10 - i);

    int firstDigit = 11 - (sum % 11);
    if (firstDigit >= 10)
        firstDigit = 0;

    // Calcular segundo dígito verificador
    sum = 0;
    for (int i = 0; i < 10; i++)
        sum += (cpf[i] - '0') * (11 - i);

    int secondDigit = 11 - (sum % 11);
    if (secondDigit >= 10)
        secondDigit = 0;

    // Verificar se os dígitos verificadores são válidos
    return (cpf[9] - '0') == firstDigit && (cpf[10] - '0') == secondDigit;
}

bool IsValidEmail(string email)
{
    try
    {
        MailAddress mailAddress = new MailAddress(email);
        return true;
    }
    catch (FormatException)
    {
        return false;
    }
}

#endregion

#region [exemplo1-ajustado]
//var pessoa = new Pessoa
//{
//    CPF = new CPF("123.456.789-00"),
//    Email = new Email("tadriano@fiap.com")
//};

//Console.WriteLine("CPF é válido? " + (pessoa.CPF.IsValid() ? "Sim" : "Não"));
//Console.WriteLine("Email é válido? " + (pessoa.Email.IsValid() ? "Sim" : "Não"));


#endregion


Console.ReadLine();
