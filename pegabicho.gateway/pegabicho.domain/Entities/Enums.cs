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
            CNH = 5,

            [Display(Description = "Conselho Regional de Medicina Veterinária")]
            CRMV = 6,
        }

        public enum UserType
        {
            [Display(Description = "Cliente", GroupName = "Clientes")]
            Client = 1,

            [Display(Description = "Passeador", GroupName = "Prestadores")]
            Walker = 2,

            [Display(Description = "Motorista", GroupName = "Prestadores")]
            Rider = 3,

            [Display(Description = "Entregador", GroupName = "Prestadores")]
            Deliveryman = 4,

            [Display(Description = "Adestrador", GroupName = "Prestadores")]
            Trainer = 5,

            [Display(Description = "Hotelaria", GroupName = "Prestadores")]
            Hostel = 6,

            [Display(Description = "Adestrador", GroupName = "Prestadores")]
            Veterinary = 7,

            [Display(Description = "Vendedor", GroupName = "Vitrine")]
            Bargainer = 8,

            [Display(Description = "Fornecedor", GroupName = "Vitrine")]
            Outfitter = 9,

            [Display(Description = "Gerente", GroupName = "Vitrine")]
            Manager = 10,

            [Display(Description = "Operador", GroupName = "BackOffice")]
            Operator = 11,

            [Display(Description = "Supervisor", GroupName = "BackOffice")]
            Supervisor = 12,

            [Display(Description = "Administrador", GroupName = "BackOffice")]
            Admin = 13,

            [Display(Description = "Mestre dos Magos", GroupName = "Shadow Florest")]
            Root = 99,
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

        #region [ Ticket Manager ]

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

            [Display(Description = "Rechamada")]
            CallBack = 4,

            [Display(Description = "Processado")]
            Processed = 5,
        }

        #endregion

        #region [ Access Manager ]

        public enum AuthPlataform
        {
            /// <summary>
            /// App cliente, institucional, vitrine (consumidor)
            /// </summary>
            [Display(Description = "Autenticação Cliente")]
            Client = 1,

            /// <summary>
            /// App consumidor
            /// </summary>
            [Display(Description = "Autenticação Prestador")]
            Customer = 2,

            /// <summary>
            /// Vitrine (empresa)
            /// </summary>
            [Display(Description = "Vitrine")]
            Vitrine = 3,

            /// <summary>
            /// Backoffice da empresa
            /// </summary>
            [Display(Description = "Backoffice")]
            BackOffice = 4,

            /// <summary>
            /// Acesso pika da porra toda
            /// </summary>
            [Display(Description = "Like a Shadow")]
            Shadow = 5,
        }

        [Flags]
        public enum ModuleService
        {
            [Display(Description = "Transporte")] //[1]
            Transport = 1 << 0,

            [Display(Description = "Estetica")] //[2]
            Estetica = 1 << 1,

            [Display(Description = "Carteira de Saúde")] //[4]
            HealthInsurance = 1 << 2,
        }

        [Flags]
        public enum RoleAccess
        {
            [Display(Description = "Visualisar")] //[1]
            View = 1 << 0,

            [Display(Description = "Editar")] //[2]
            Edit = 1 << 1,

            [Display(Description = "Compartilhar")] //[4]
            Share = 1 << 2,

            [Display(Description = "Deletar Virtualmente")] //[8]
            SoftDelete = 1 << 3,

            [Display(Description = "Deletar")] //[16]
            Delete = 1 << 4,

            [Display(Description = "Sistema")] //[16]
            Admin = 1 << 5,

            [Display(Description = "Raiz")] //[32]
            Root = 1 << 6,
        }

        [Flags]
        public enum LevelAccess
        {
            [Display(Description = "Plebeu")]
            BasicReadOnly = (RoleAccess.View | RoleAccess.Share),

            [Display(Description = "Patriarca")]
            Basic = (RoleAccess.View | RoleAccess.Edit | RoleAccess.SoftDelete | RoleAccess.Share),

            [Display(Description = "Ansião")]
            Admin = (Basic | RoleAccess.Admin),

            [Display(Description = "Mestre dos Magos")]
            Root = (Admin | RoleAccess.Root)
        }

        #endregion
    }
}