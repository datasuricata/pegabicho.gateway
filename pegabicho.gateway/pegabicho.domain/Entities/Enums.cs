using System;
using System.ComponentModel.DataAnnotations;

namespace pegabicho.domain.Entities
{
    public static class Enums
    {
        public enum RequestMethod
        {
            Get = 1,
            Post = 2,
            Put = 3,
            Delete = 4,
        }

        public enum PaymentType
        {
            [Display(Description = "Não Definido")]
            Uninformed = 0,

            [Display(Description = "Pagamento com Crédito")]
            Credit = 1,

            [Display(Description = "Pagamento com Débito")]
            Debit = 2,

            [Display(Description = "Pagamento com Boleto Bancário")]
            BankSlip = 3
        }

        public enum DocumentType
        {
            [Display(Description = "Registro Geral")]
            RG = 1,

            [Display(Description = "Cadastro de Pessoa Física")]
            CPF = 2,

            [Display(Description = "Cadastro Nacional da Pessoa Jurídica")]
            CNPJ = 3,

            [Display(Description = "Certificado de Registro de Veículo")]
            CRV = 4,

            [Display(Description = "Carteira Nacional de Habilitação")]
            CNH = 5
        }

        public enum UserType
        {
            [Display(Description = "Cliente")]
            Client = 1,

            [Display(Description = "Guincheiro")]
            Winder = 2,

            [Display(Description = "Operador")]
            Operator = 3,

            [Display(Description = "Administrador")]
            Administrator = 4,

            [Display(Description = "Super Usuário")]
            Super = 99,
        }

        public enum GenderType
        {
            [Display(Description = "Não Definido")]
            Uninformed = 0,

            [Display(Description = "Masculino")]
            Male = 1,

            [Display(Description = "Feminino")]
            Female = 2,
        }

        public enum UserStage
        {
            [Display(Description = "Pendente Aprovação")]
            Pending = 1,

            [Display(Description = "Aprovado")]
            Aproved = 2,

            [Display(Description = "Recusado")]
            Recused = 3,

            [Display(Description = "Bloqueado")]
            Blocked = 4
        }

        public enum LogType
        {
            Uninformed = 0,
            Register = 1,
            Update = 2,
            Delete = 3,
            SoftDelete = 4,
            Exception = 5
        }

        public enum BuildingType
        {
            [Display(Description = "Casa")]
            House = 1,

            [Display(Description = "Sobrado")]
            Townhouse = 2,

            [Display(Description = "Apartamento")]
            Apartment = 3,

            [Display(Description = "Comercial")]
            Commercial = 4,
        }

        public enum TicketType
        {
            [Display(Description = "Particular")]
            Private = 1,

            [Display(Description = "Comercial")]
            Comercial = 2
        }

        public enum TicketStatus
        {
            [Display(Description = "Aguardando")]
            Waiting = 1,

            [Display(Description = "Designado")]
            Designed = 2,

            [Display(Description = "Reprovado")]
            Reproved = 3,

            [Display(Description = "Processado")]
            Processed = 4,

            [Display(Description = "Rechamada")]
            CallBack = 5,
        }

        [Flags] //TODO User Access
        public enum UserRole
        {
            #region [ attributes ]

            [Display(Description = "View")] //[1]
            View = 1 << 0,

            [Display(Description = "Edit")] //[2]
            Edit = 1 << 1,

            [Display(Description = "SoftDelete")] //[4]
            SoftDelete = 1 << 2,

            [Display(Description = "Share")] //[8]
            Share = 1 << 3,

            [Display(Description = "App")] //[16]
            App = 1 << 4,

            [Display(Description = "BackOffice")] //[32]
            BackOffice = 1 << 5,

            [Display(Description = "Site")] //[64]
            Site = 1 << 6,

            [Display(Description = "Delete")] //[128]
            Delete = 1 << 7,

            [Display(Description = "Root")]
            Root = 1 << 99,

            #endregion

            #region [ perfis ]

            [Display(Description = "Basic")] //15
            Basic = (View | Edit | SoftDelete | Share),

            [Display(Description = "Winder")] //95
            Winder = (Basic | App | Site),

            [Display(Description = "Operator")] //47
            Operator = (Basic | BackOffice),

            [Display(Description = "Administrator")] //175
            Administrator = (Basic | BackOffice | Delete),

            [Display(Description = "Administrador do Sistema")] //?
            SM = (Basic | App | Site | BackOffice | Delete | Root),

            #endregion
        }

        public enum AuthPlataform
        {
            [Display(Description = "Aplicativo")]
            App = 0,

            [Display(Description = "Site Institucional")]
            Site = 1,

            [Display(Description = "Site de Controle Interno")]
            BackOffice = 2,
        }
    }
}
