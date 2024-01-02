using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected bool ExecutarValidacao<TValidacao, TEntidade>(TValidacao validacao, TEntidade entidade) 
            where TValidacao : AbstractValidator<TEntidade>
            where TEntidade : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }

        protected void Notificar(string mensagem) 
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors) 
            {
                Notificar(item.ErrorMessage);
            }
        }
    }
}
