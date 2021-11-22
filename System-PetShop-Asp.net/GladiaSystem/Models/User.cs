using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace GladiaSystem.Models
{
    public class User
    {
        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Insira um nome válido")]
        public string name { get; set; }

        [Required(ErrorMessage = "A confirmação do nome é obrigatória!")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Insira um nome válido")]
        public string confName { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um email válido")]
        [Required(ErrorMessage = "O Email é obrigatório!")]
        public string email { get; set; }

        [Display(Name = "CPF (sem pontuação)")]
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^.{11,}$", ErrorMessage = "Digite um CPF válido")]
        public string Cpf { get; set; }

        [RegularExpression(@"([a-zA-Z]{1,})([0-9]{1,})", ErrorMessage = "Insira uma senha válida (Uma letra maiúscula e um número)")]
        [Required(ErrorMessage = "A Senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Celular (Com DDD)")]
        [Required(ErrorMessage = "O número de celular é obrigatório")]
        [RegularExpression(@"^.{11,}$", ErrorMessage = "Minímo de 11 número")]
        public string Celular { get; set; }

        [RegularExpression(@"([a-zA-Z]{1,})([0-9]{1,})", ErrorMessage = "Insira uma senha válida (Uma letra maiúscula e um número)")]
        [Required(ErrorMessage = "A Confirmar senha é obrigatório!")]
        [DataType(DataType.Password)]
        public string confPassword { get; set; }

        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Insira o Cep corretamente")]
        [Required(ErrorMessage = "O campo Cep é obrigatório!")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório!")]
        [RegularExpression(@"^[0-9]{2}$", ErrorMessage = "Insira o UF corretamente")]
        public string UF { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatório!")]
        public string City { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório!")]
        public string District { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório!")]
        public string PublicPlace { get; set; }

        public string Complement { get; set; }

        public string img { get; set; }

        public string userLvl { get; set; }

        public string userID { get; set; }

        [Display(Name = "UF")]
        public BrUf BrUf { get; set; }

        public User()
        {
            BrUf = new BrUf();
        }

    }
}
