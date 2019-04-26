using System;
using System.ComponentModel.DataAnnotations;

namespace pegabicho.domain.Entities {
    public static class Enums {
        #region [ request ]

        public enum RequestMethod {
            Get = 1,
            Post = 2,
            Put = 3,
            Delete = 4,
        }

        #endregion

        #region [ pet ]

        public enum PetSize {
            [Display(Description = "Não Definido")]
            Uninformed = 0,

            [Display(Description = "Porte Pequeno")]
            Small = 1,

            [Display(Description = "Porte Médio")]
            Medium = 2,

            [Display(Description = "Porte Grande")]
            Big = 3,

            [Display(Description = "Porte Gigante")]
            Giant = 4,
        }

        public enum PetSpecie {
            [Display(Description = "Cão")]
            Dog = 0,

            [Display(Description = "Gato")]
            Cat = 1,
        }

        #endregion

        #region [ payment ]

        public enum PaymentType {
            [Display(Description = "Não Definido")]
            Uninformed = 0,

            [Display(Description = "Pagamento com Crédito")]
            Credit = 1,

            [Display(Description = "Pagamento com Débito")]
            Debit = 2,

            [Display(Description = "Pagamento com Boleto Bancário")]
            BankSlip = 3
        }

        #endregion

        #region [ user ]

        public enum DocumentType {
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

        public enum UserType {
            [Display(Description = "Cliente")]
            Customer = 1,

            [Display(Description = "Prestador")]
            Provider = 2,

            [Display(Description = "Empresa")]
            Enterprise = 3,

            [Display(Description = "Administrativo")]
            Administrative = 4,

            [Display(Description = "Mestre dos Magos")]
            Root = 99,
        }

        public enum GenderType {
            [Display(Description = "Não Definido")]
            Uninformed = 0,

            [Display(Description = "Masculino")]
            Male = 1,

            [Display(Description = "Feminino")]
            Female = 2,
        }

        public enum UserStage {
            [Display(Description = "Pendente Aprovação")]
            Pending = 1,

            [Display(Description = "Aprovado")]
            Aproved = 2,

            [Display(Description = "Recusado")]
            Recused = 3,

            [Display(Description = "Bloqueado")]
            Blocked = 4
        }

        public enum BuildingType {
            [Display(Description = "Casa")]
            House = 1,

            [Display(Description = "Sobrado")]
            Townhouse = 2,

            [Display(Description = "Apartamento")]
            Apartment = 3,

            [Display(Description = "Comercial")]
            Commercial = 4,
        }

        #endregion

        #region [ logging ]

        public enum LogType {
            Uninformed = 0,

            Register = 1,
            Update = 2,
            Delete = 3,
            SoftDelete = 4,
        }

        #endregion

        #region [ survey ]

        public enum SurveyType {
            [Display(Description = "Retirada")]
            Gathering = 1,

            [Display(Description = "Entrada")]
            Entry = 2,

            [Display(Description = "Entrega")]
            Output = 3,

        }

        public enum SurveyImage {
            [Display(Description = "Assinatura do Responsável")]
            ResponserSub = 1,

            [Display(Description = "Assinatura do Funcionario")]
            ResceiverSub = 2,

            [Display(Description = "Assinatura de Retorno")]
            ReturnerSub = 3
        }

        #endregion

        #region [ ticket ]

        public enum TicketType {
            [Display(Description = "Particular")]
            Private = 1,

            [Display(Description = "Comercial")]
            Comercial = 2
        }

        public enum TicketStatus {
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

        #region [ access ]

        public enum AuthPlataform {

            /// <summary>
            /// App cliente, institucional, vitrine (consumidor)
            /// </summary>
            [Display(Description = "Autenticação Cliente")] //App
            Customer = 1,

            /// <summary>
            /// App consumidor
            /// </summary>
            [Display(Description = "Autenticação Prestador")] //App
            Provider = 2,

            /// <summary>
            /// Vitrine (empresa)
            /// </summary>
            [Display(Description = "Vitrine")] //Vitrine
            Showplace = 3,

            /// <summary>
            /// Backoffice da empresa
            /// </summary>
            [Display(Description = "Backoffice")] //Interno
            BackOffice = 4,

            /// <summary>
            /// Acesso pika da porra toda
            /// </summary> 
            [Display(Description = "Like a Shadow")] //Foda
            Shadow = 5,
        }

        [Flags]
        public enum ModuleService {
            [Display(Description = "Básico")]
            Base = 0,

            [Display(Description = "Transporte")]
            Transport = 1,
        }

        [Flags]
        public enum RoleAccess {
            [Display(Description = "Visualisar")] //[1]
            View = 1 << 0,

            [Display(Description = "Compartilhar")] //[2]
            Share = 1 << 1,

            [Display(Description = "Criar")] //[4]
            Create = 1 << 2,

            [Display(Description = "Editar")] //[8]
            Edit = 1 << 3,

            [Display(Description = "Deletar Virtualmente")] //[16]
            SoftDelete = 1 << 4,

            [Display(Description = "Deletar")] //[32]
            Delete = 1 << 5,

            [Display(Description = "Sistema")] //[64]
            Admin = 1 << 6,

            [Display(Description = "Raiz")] //[128]
            Root = 1 << 7,
        }

        [Flags]
        public enum LevelAccess {
            [Display(Description = "Plebeu")] //[3]
            BasicReadOnly = (RoleAccess.View | RoleAccess.Share),

            [Display(Description = "Patriarca")] //[31]
            Basic = (BasicReadOnly | RoleAccess.Create | RoleAccess.Edit | RoleAccess.SoftDelete),

            [Display(Description = "Ansião")] //[127]
            Admin = (Basic | RoleAccess.Delete | RoleAccess.Admin),

            [Display(Description = "Mestre dos Magos")] //[255]
            Root = (Admin | RoleAccess.Root)
        }

        #endregion
    }
}