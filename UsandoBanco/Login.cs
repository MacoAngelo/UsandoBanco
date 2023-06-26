using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsandoBanco.Criptografias;

namespace UsandoBanco
{
    internal class Login
    {
        private bool _autenticado = false;
        public string Nickname { get; private set; }

        public Login(string nickname, string password)
        {
            var usuario = new Usuario(nickname);

            if (usuario.Id > 0 && ValidPassword(password, usuario))
            {
                _autenticado = true;
                Nickname = usuario.Nickname;
            }
        }

        private bool ValidPassword(string password, Usuario user)
        {
            var passwordHash = HashGenerator.GenerateHash(password, HashType.MD5);
            return passwordHash.ToUpper() == user.Password;
        }

        public bool Autenticado()
        {
            return _autenticado;
        }
    }
}