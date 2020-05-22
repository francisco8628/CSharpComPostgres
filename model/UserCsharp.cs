using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexaoComDB.model
{
    class UserCsharp
    {
		private long id;
		private string nome;
		private string email;
		private bool erroId;  //varia para verificar idExistente
		public long getId()
		{
			return id;
		}
		public void setId(long id)
		{
			this.id = id;
		}
		public string getNome()
		{
			return nome;
		}
		public void setNome(string nome)
		{
			this.nome = nome;
		}
		public string getEmail()
		{
			return email;
		}
		public void setEmail(string email)
		{
			this.email = email;
		}
		public override bool Equals(object obj)
		{
			return obj is UserCsharp csharp &&
				   id == csharp.id &&
				   nome == csharp.nome &&
				   email == csharp.email;
		}
		public void SetErroId(bool erroId)
		{
			this.erroId = erroId;

			if (erroId)
			{
				erroId= true;
			}
			else
				 erroId = false;
		}

		public bool GetErroId()
		{
			return erroId;
		}
		public override int GetHashCode()
		{
			var hashCode = -620901481;
			hashCode = hashCode * -1521134295 + id.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nome);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
			return hashCode;
		}
	}
}
