using DevIO.Business.Models;
using FluentValidation;

namespace DevIO.Business.Services
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TValidacao, TEntidade>(TValidacao validacao, TEntidade entidade) 
            where TValidacao : AbstractValidator<TEntidade>
            where TEntidade : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            return false;
        }

        protected void Notificar(string mensagem) 
        {
        }
    }
}
