using System.Net.WebSockets;
using UsandoBanco;
using UsandoBanco.Criptografias;

var usuarioErick = new Usuario("v.m", "3", true);
usuarioErick.Save();

Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");
Console.WriteLine("         Login         ");
Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

Console.Write("Informe o seu usuário: ");
var nickname = Console.ReadLine();

Console.Write("Informe a sua senha: ");
var password = Console.ReadLine();

var loginInfo = new Login(nickname, password);
if (loginInfo.Autenticado())
{
    Console.WriteLine($"Bem-vindo usuário {loginInfo.Nickname}");
}
else
{
    Console.WriteLine("Usuário ou senha inválidos!");
}

Console.ReadLine();
//var menu = new Menu();
//menu.ChamarMenu();